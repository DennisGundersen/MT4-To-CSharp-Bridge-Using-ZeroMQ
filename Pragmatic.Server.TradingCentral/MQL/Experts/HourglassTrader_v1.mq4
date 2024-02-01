//+------------------------------------------------------------------+
//|                                           HourglassTrader_v1.mq4 |
//|                                              Dennis Gundersen AS |
//|                                  https://www.dennisgundersen.com |
//+------------------------------------------------------------------+
#property copyright "Dennis Gundersen AS"
#property link      "https://www.dennisgundersen.com"
#property version   "1.01"
//uncomment to Print Debug information related to ZeroMQ communication
//#define DBG_ZMQ
//for debugging multiframe receive
//#define DBG_ZMQ_RCV

#include <Tools.mqh>
#include <CommunicationBase.mqh>
#include <DTOs.mqh>

//Address of the server
input string   server="tcp://127.0.0.1:9001";
//Those give advanced options over socket - could be also not input
input int      connectTimeout=1000; //connect timeout [ms]
input int      receiveTimeout=3000; //receive timeout [ms]
input int      sendTimeout=4000; //send timeout [ms]
input int      reconnectInterval=2000; //reconnect interval [ms]
input int      reconnectIntervalMax=30000; //max reconnect interval [ms]



extern string  TradingVariables = "------------------------------------------";
extern bool    IsTrader = false;                   // Run as Viewer or Trader?
extern double  TradingLotSize = 0.01;              // Trading Lot Size
extern bool    TradeMidTerm = false;               // Trade Mid-Term

extern string  StatisticsVariables = "------------------------------------------";
extern double  TestUpToRate = 0.0000;              // Test Up To Rate
extern double  TestDownToRate = 0.0000;            // Test Down To Rate
extern int     TestPipsUp = 300;                   // Test Pips Up
extern int     TestPipsDown = 300;                 // Test Pips Down
extern int     CrashPips = 400;                    // Test distance for crash
extern bool    RunStats = true;                    // Run Stats
extern int     UpdateScreenTimer = 2;              // Run Timer in seconds
extern int     UpdateAccountTimer = 5;             // Run Timer in seconds
extern int     UpdateHistoryTimer = 10;            // Run Timer in seconds
int            rateDecimalNumbersToShow = 4;		   // Rate Decimal Numbers To Show

extern string  StrategyVariables = "------------------------------------------";
extern int	   LongStabilizerSizeFactor = 1;       // Long Stabilizer Size Factor
extern int	   ShortStabilizerSizeFactor = 1;      // Short Stabilizer Size Factor
extern int     LongBalancerSizeFactor = 0;         // Long Balancer Size Factor
extern int     ShortBalancerSizeFactor = 0;        // Short Balancer Size Factor
extern int     PrimerSizeFactor = 3;			   // Primer Size Factor
extern int		BalancerMinPlacementDistanceLongs = 100;
extern int		BalancerMinPlacementDistanceShorts = 100;
extern int     BalancerStopLossPips = 50;         // Balancer StopLoss Pips
extern int     SecurePips = 0;                     // Secure Pips
extern bool    RunBalancers = false;               // Run Balancers
extern bool    RunStabilizers = true;             // Run Stabilizers
extern bool    RunBreakouts = false;               // Run Breakouts
extern bool    RunPrimers = true;                 // Run Primers
extern bool    AutoCloseExtremes = false;          // Auto-close Extremes when balance is restored
extern bool    RunWhiplash = false;                 

extern string  SystemVariables = "------------------------------------------";
extern string  NameOfAccount = "DEV";          // Account Name
extern bool	   IsAccountMaster = true;			   // Only master saves deposits from history
extern bool    IsSymbolMaster = true;             // Only Symbol Master Account sends volatility update calls to client
extern double  AccountPercentage = 1.00;           // Percentage of account balance to give this pair
extern int     HeartbeatMonitorTimer = 0;         // Heartbeat Monitor Timer in minutes
extern int     DatabaseLogTimer = 5;               // Database Log Timer in minutes
extern int     WarningLevel = 50;                  // Warning Level for volatility in pips
extern int     ScreenshotTimer = 5;                // Screenshot Timer in minutes
extern double  ExtremeTopRate = 1.5000;            // Top Rate
extern double  NormalTopRate = 0.0000;             // Long Top
extern double  CenterRate = 0.0000;				   // Preferred Center Rate
extern double  NormalBottomRate = 0.0000;          // Long Bottom
extern double  ExtremeBottomRate = 0.0000;         // Bottom Rate
extern int     MaxPlacementDistance = 300;         // Max Placement Distance
extern int     MaxWeight = 20;				   // Max weight differential that allows TP instead of SL
extern int     TakeProfit = 49;                    // Take Profit
extern int     FixedSpread = 1;                    // Fixed Spread
extern int     ExtraLongBuffer = 1;                // Extra Long Buffer
extern int     ExtraShortBuffer = 1;               // Extra Short Buffer
extern double  Commission = 0.00;                  // Commission per lot
bool           AutoLotIncrease = false;			  	   // Auto Lot Increase
int            AutoLotSafeEQLevel = 40;				   // Auto Lot Safe EQ Level
extern int     GMTOffset = 2;

int            magicNumberRegulars = 1;            // MagicNumber Regulars
int            magicNumberBalancers = 2;           // MagicNumber Balancers

double         usePoint;                           // Digit calculation for current account (2/4 or 3/5 decimals)
static int     timeUpdated = 0;                    // Timer for last run of update checks
static int     timeRegistered = 0;                 // Timer for last attempt to register account
static int     timeScreenshot = 0;                 // Timer for last screenshot
static int     timeStatistics = 0;                 // Timer for last UI update
static int     timeHistory = 0;                    // Timer for last history check

//int            accountNumber = 0;
string         brokerName = "";

// Fonts and placement of stats
extern string  LayoutVariables = "------------------------------------------";
extern color   ActiveColor = Navy;
extern color   NormalColor = Black;
extern color   UpwardsColor = Green;
extern color   DownwardsColor = Red;
extern color   CenterColor = Magenta;
extern color	GridColor = Green;
extern int		GridLevelsAside = 10;
extern bool		HideGridLabels = true;
extern string  GoodSound;   // Name of PROFIT wav file in terminal_directory\Sounds.
extern string  BadSound;    // Name of LOSS wav file in terminal_directory\Sounds.

extern int     SmallFontSize = 8;
extern int     NormalFontSize = 9;
extern int     LargeFontSize = 10;
extern int     RateFontSize = 12;
extern string  FontName = "Arial";

extern double  Line_1_Vertical = 0.00;
extern double  Line_2_Vertical = 20.00;
extern double  Line_3_Vertical = 40.00;
extern double  Line_4_Vertical = 60.00;
extern double  Line_5_Vertical = 80.00;
extern double  Line_6_Vertical = 100.00;
extern double  Line_7_Vertical = 120.00;

extern int     Grid_1_Horizontal = 10;
extern int     Grid_2_Horizontal = 150;
extern int     Grid_3_Horizontal = 350;
extern int     Grid_4_Horizontal = 650;
extern int     Grid_5_Horizontal = 950;
extern int     Grid_6_Horizontal = 1070;
extern int     Grid_7_Horizontal = 1200;

double         longs = 0;
double         shorts = 0;
double         cost = 0;
int            orderCount = 0;
int            currentStep = 0;
double         tradingSize = 0;
double         nextLot = 0;
double         nextIncrease = 0;
int            tradeCountdown = 999;

double         upwardsRate = 0; 
double         upwardsEquity = 0;
double         upwardsBalance = 0;
double         upwardsLongs = 0;
double         upwardsShorts = 0;

double         centerRate = 0; 
double         centerEquity = 0;
double         centerBalance = 0;
double         centerLongs = 0;
double         centerShorts = 0;
   
double         downwardsRate = 0; 
double         downwardsEquity = 0;
double         downwardsBalance = 0;
double         downwardsLongs = 0;
double         downwardsShorts = 0;

double         topBorderRate = 0; 
double         topBorderEquity = 0;
double         topBorderBalance = 0;
double         topBorderLongs = 0;
double         topBorderShorts = 0;
   
double         bottomBorderRate = 0; 
double         bottomBorderEquity = 0;
double         bottomBorderBalance = 0;
double         bottomBorderLongs = 0;
double         bottomBorderShorts = 0;

//int            lastUpdateTime = -1;
int            lastOrderClose = -1;
bool           registrationError = false;
double         currentSpread = 0;
double         maxSpread = 0;
bool           isAccountRegistered = false;
bool           isTraderRegistered = false;
double		   runningBalancingLongLots = 0;
double		   runningBalancingShortLots = 0;

double			top = 0;
double			bottom = 0;
double			gridSize = 0;
double			gridTopRefreshRate = 0;
double			gridBottomRefreshRate = 0;
double         balance;
double         gridTopRate = 0;
double         gridBottomRate = 0;
double         volatilityUpRate = 0;
double         volatilityDownRate = 0;

int            accountId = 0;
double         stepGrowthFactor = 0;
double         startingBalance = 0;
int            startFactor = 0;
//datetime       lastOrderClose;
//double         alerts[1][4];  // Two dimensional array to hold the alerts [rows][alertID, rate, above, active]. Use ArrayResize(alerts, rows) to change it.
//string         message = "";
double         weight = 0;

// HTTP variables start
string         cookie = NULL;
string         referrer = NULL;
int            timeout = 5000;
string         headers = "Content-Type: application/json";
string         serverHeaders = NULL;
string         jsonString = "";
datetime       unixEpoch = D'1970-01-01 00:00:00';
// HTTP variables end

int OnInit()
{
   if(ConnectToTradingCentral())
   {
         TestRegisterHourglassAccountOnServer();
         TestRegisterHourglassTradesOnServer(true, 3);
         TestGetHourglassAccountOverviewOnServer();
         return(INIT_SUCCEEDED);
   }
   else
   {
      Print("Communication problem: " + CommLastError);
   }
   return INIT_FAILED;
}


void OnDeinit(const int reason)
{
}

void OnTick()
{

}

bool TestRegisterHourglassAccountOnServer()
{
	HourglassAccountRegistrationDTO registrationDTO;      // Instantiation
	FillHourglassAccountRegistrationDTO(registrationDTO); // Collect data and fill in all the variables
	HourglassAccountRegistrationResultDTO responseDTO;

   PrintFormat("Now calling RegisterHourglassAccountOnServer with AccountNumber{%d} and AccountName{%s} was created", registrationDTO.accountNumber, registrationDTO.accountName);
	RegisterHourglassAccountOnServer(responseDTO, registrationDTO);
	PrintFormat("Returned to TestRegisterHourglassAccountOnServer(). Round complete!!!");
	return true;
}

void FillHourglassAccountRegistrationDTO (HourglassAccountRegistrationDTO &reg)
{
	reg.accountNumber = AccountNumber();                                          // 1
	reg.accountName = NameOfAccount;                                              // 2 NameOfAccount
	reg.symbol = Symbol();                                                        // 3
   reg.tradingLotSize = TradingLotSize;                                          // 4
   reg.extremeTopRate = ExtremeTopRate;                                          // 5
   reg.normalTopRate = NormalTopRate;                                            // 6
   reg.centerRate = CenterRate;                                                  // 7
   reg.normalBottomRate = NormalBottomRate;                                      // 8
   reg.extremeBottomRate = ExtremeBottomRate;                                    // 9
   reg.maxPlacementDistance = MaxPlacementDistance;                              // 10
   reg.testUpToRate = TestUpToRate;                                              // 11
   reg.testDownToRate = TestDownToRate;                                          // 12
   reg.testPipsUp = TestPipsUp;                                                  // 13
   reg.testPipsDown = TestPipsDown;                                              // 14
   reg.balancerMinPlacementDistanceLongs = BalancerMinPlacementDistanceLongs;    // 15
   reg.balancerMinPlacementDistanceShorts = BalancerMinPlacementDistanceShorts;  // 16
   reg.longStabilizerSizeFactor = LongStabilizerSizeFactor;                      // 17
   reg.shortStabilizerSizeFactor = ShortStabilizerSizeFactor;                    // 18
   reg.longBalancerSizeFactor = LongBalancerSizeFactor;                          // 19
   reg.shortBalancerSizeFactor = ShortBalancerSizeFactor;                        // 20
   reg.primerSizeFactor = PrimerSizeFactor;                                      // 21
   reg.balancerStopLossPips = BalancerStopLossPips;                              // 22
   reg.securePips = SecurePips;                                                  // 23
   reg.autoLotIncrease = AutoLotIncrease;                                        // 24
   reg.autoLotSafeEQLevel = AutoLotSafeEQLevel;                                  // 25
   reg.takeProfit = TakeProfit;                                                  // 26
   reg.tradeMidTerm = TradeMidTerm;                                              // 27
   reg.fixedSpread = FixedSpread;                                                // 28
   reg.extraLongBuffer = ExtraLongBuffer;                                        // 29
   reg.extraShortBuffer = ExtraShortBuffer;                                      // 30
   reg.warningLevel = WarningLevel;                                              // 31
   reg.heartbeatMonitorTimer = HeartbeatMonitorTimer;                            // 32
   reg.databaseLogTimer = DatabaseLogTimer;                                      // 33
   reg.autoCloseExtremes = AutoCloseExtremes;                                    // 34
   reg.runBalancers = RunBalancers;                                              // 35
   reg.runStabilizers = RunStabilizers;                                          // 36
   reg.runBreakouts = RunBreakouts;                                              // 37
   reg.runWhiplash = RunWhiplash;                                                // 38
   reg.runPrimers = RunPrimers;                                                  // 39
   reg.gmtOffset = GMTOffset;                                                    // 40
   reg.usePoint = usePoint;                                                      // 41
   reg.rateDecimalNumbersToShow = rateDecimalNumbersToShow;                      // 42
   reg.isAccountMaster = IsAccountMaster;                                        // 43
   reg.isSymbolMaster = IsSymbolMaster;                                          // 44
   reg.screenshotTimer = ScreenshotTimer;                                        // 45
   reg.maxWeight = MaxWeight;                                                    // 46
}


bool RegisterHourglassAccountOnServer(HourglassAccountRegistrationResultDTO &resultDTO, HourglassAccountRegistrationDTO &registrationDTO)
{
   
	const string commandName = "RegisterHourglassAccount";
	string payload[];    //send buffer
	string response[];   //response buffer
	
	//compute size 
	int bufferSize = 1 + registrationDTO.Length(); //command name
	if(ArrayResize(payload, bufferSize) == bufferSize)
	{
		int i = -1; //last element of buffer
		payload[++i] = commandName;
		//PrintFormat("Now calling serialization on registrationDTO");
		registrationDTO.Serialize(payload, i); //serialize the HourglassAccountRegistrationDTO class into the buffer
		
		// Send the payload to the TradingCentral
		//PrintFormat("Now calling TradingCentral with payload and response object");
		bool r = CommSendCommand(response, payload);
		if(r)
		{
			//CommShowResponse(commandName, response); //this is for debugging only - dump received buffer
			if(response[0] == "OK")
			{
				int respSize = ArraySize(response);
				//optionally check if received expected number of frames - it's mostly possible for static
				int expSize = 1 + resultDTO.Length();
				
				if(respSize != expSize)
				{
					PrintFormat("%s Error: Expected %d, but received %d", commandName, expSize, respSize);
					return false;
				}
				
				//region Deserialization - convert received strings into right types
				i = 0; //will start after status in response[0]
				//PrintFormat("Response object successfully received from TradingCentral. Trying to deserialize...");
				resultDTO.Deserialize(response, i);
				//PrintFormat("Response object successfully deserialized");
				//endregion
				return true;
			}
			else
			{
				PrintFormat("%s Error: `%s`", commandName, response[1]);
			}
		}
		else
		{
			PrintFormat("%s no response - error: `%s`", commandName, CommGetLastError());
		}
	}
	else
	{
		PrintFormat("%s - problem during creating buffer string[%d]", commandName, bufferSize);
	}
	return false;
}

int TestRegisterHourglassTradesOnServer(bool mock = false, int mockOrders = 0)
{
   //PrintFormat("Starting TestRegisterHourglassTradesOnServer()");
	OrderDTO orders[];
	ChangeOrderDTO changeOrders[];

	//test data
	double ask = 1.0;
	double bid = 2.9;
	double balance = 5000.0;
	double equity = 200;
	int maxOrderCount = mockOrders; 

		balance = AccountBalance();
		equity = AccountEquity();
		ask = Ask;
		bid = Bid;
	
	//get from mt - more real usage
	if(!mock)
	{
		maxOrderCount = OrdersTotal();
	} 
	
	if(maxOrderCount == ArrayResize(orders, maxOrderCount))
	{
		int j = 0;

		for(int i = 0; i < maxOrderCount; i++)
		{
			if(mock)
			{
			   PrintFormat("Creating mock order");
				orders[j].MockThis(j);
				j++;
			}
			else
			{	
				if(OrderSelect(i, SELECT_BY_POS, MODE_TRADES) && OrderSymbol() == Symbol())
				{
					orders[++j] = OrderDTO(true, accountId); //constructor has option to fill fields using Order*() methods, of course it has to be called after OrderSelect
				}
			}
		}
		
      //PrintFormat("Calling RegisterHourglassTradesOnServer(changeOrders, orders, ask, bid, balance, equity)");
		bool ok = RegisterHourglassTradesOnServer(changeOrders, orders, ask, bid, balance, equity);
		if(ok)
		{
			//PrintFormat("RegisterHourglassTradesOnServer has returned result successfully.");
			return ArraySize(changeOrders);
		}
		PrintFormat("RegisterHourglassTradesOnServer error");

	} 
	else
	{
		PrintFormat("Couldn't initialize (resize) Orders array to take %d elements", maxOrderCount);
	}
	return -1;
}

bool RegisterHourglassTradesOnServer(ChangeOrderDTO& result[], OrderDTO& orders[], double ask, double bid, double balance, double equity)
{
	const string commandName = "RegisterHourglassTrades";
	string payload[]; //send buffer
	string response[]; //response buffer
	
	//compute size 
	int numberOfOrders = ArraySize(orders);
	int bufferSize = 1;  // add space for command name
	bufferSize += 1;     // add space for OrderCount
	
	if(numberOfOrders > 0) 
	{
		bufferSize += numberOfOrders * orders[0].Length(); // # OrderDTO x 15 variables
	}
	
	bufferSize += 4;     // add space for ask, bid, balance, equity
	if(ArrayResize(payload, bufferSize) == bufferSize)
	{
		int i = -1; //last element of buffer
		payload[++i] = commandName;
		payload[++i] = IntegerToString(numberOfOrders);    //serialize the count of elements of type OrderDTO in `orders` array
		
		for(int j = 0; j < numberOfOrders; ++j)
		{
			orders[j].Serialize(payload, i);                //serialize to buffer element #j of `orders` array
		}
		
		payload[++i] = DoubleToString(ask);
		payload[++i] = DoubleToString(bid);
		payload[++i] = DoubleToString(balance);
		payload[++i] = DoubleToString(equity);
		
		//PrintFormat("Now calling TradingCentral with payload and commandName: RegisterHourglassTrades");
		bool r = CommSendCommand(response, payload);
		if(r)
		{
			//CommShowResponse(commandName, response); //this is for debugging only - dump received buffer
			if(response[0] == "OK")
			{
			   //PrintFormat("Response successfully received from TradingCentral");
				int respSize = ArraySize(response);

				//region Deserialization - convert received strings into right types
				i = 0;
				int resultLength = StringToInteger(response[++i]);    //deserialize number of elements
				if(ArrayResize(result, resultLength) != resultLength)
				{
					PrintFormat("%s Error: Result array resize problem (new size %d)", commandName, resultLength);
					return false;
				}
				for(int j = 0; j < resultLength; ++j)
				{
					result[j].Deserialize(response, i);
				}
				//endregion
            //PrintFormat("Response object is deserialized into array of ChangeOrderDTO");
				return true;
			}
			else
			{
				PrintFormat("%s Error: `%s`", commandName, response[1]);
			}
		}
		else
		{
			PrintFormat("%s no response - error: `%s`", commandName, CommGetLastError());
		}
	}
	else
	{
		PrintFormat("%s - problem during creating buffer string[%d]", commandName, bufferSize);
	}
	return false;
}


bool TestGetHourglassAccountOverviewOnServer()
{
	HourglassAccountOverviewDTO responseDTO;
   //PrintFormat("Now calling GetHourglassAccountOverviewOnServer(responseDTO, accountId: `%s`)", IntegerToString(accountId));
   
	GetHourglassAccountOverviewOnServer(responseDTO, accountId);
	//Print("GetHourglassAccountOverviewOnServer has successfully completed a round.");
	return true;
}

bool GetHourglassAccountOverviewOnServer(HourglassAccountOverviewDTO &responseDTO, int accountId)
{
	//Print("Running GetHourglassAccountOverviewOnServer(HourglassAccountOverviewDTO &responseDTO, int accountId).");

	const string commandName = "GetHourglassAccountOverview";
	string payload[];       //send buffer
	string response[];      //response buffer

	int bufferSize = 2;     // Just sending commandName + accountId, so increase payload[] by two
	if(ArrayResize(payload, bufferSize) == bufferSize)
	{
		int i = 0; 
		payload[i++] = commandName;
		payload[i++] = IntegerToString(accountId);
		
		// Send the payload to the TradingCentral
		//PrintFormat("Now calling TradingCentraL with payload and commandName: GetHourglassAccountOverview");
		bool r = CommSendCommand(response, payload);
		if(r)
		{
			//CommShowResponse(commandName, response); //this is for debugging only - dump received buffer
			if(response[0] == "OK")
			{
			   //PrintFormat("TradingCentral has successfully replied. Trying to deserialize...");
				int respSize = ArraySize(response);
				//optionally check if received expected number of frames - it's mostly possible for static
				int expSize = 1 + responseDTO.Length();
				
				if(respSize != expSize)
				{
					PrintFormat("%s Error: Expected %d, but received %d", commandName, expSize, respSize);
					return false;
				}
				
				//region Deserialization - convert received strings into right types
				i = 0; //will start after status in response[0]
				responseDTO.Deserialize(response, i);
				//PrintFormat("HourglassAccountOverviewDTO test - Bal: %s, Eq: %s, BottomRate: %s", DoubleToString(responseDTO.Balance, 2), DoubleToString(responseDTO.Equity,2), DoubleToString(responseDTO.BottomRate,4));
				//PrintFormat("HourglassAccountOverviewDTO successfully deserialized.");
				//endregion
				return true;
			}
			else
			{
				PrintFormat("%s Error: `%s`", commandName, response[1]);
			}
		}
		else
		{
			PrintFormat("%s no response - error: `%s`", commandName, CommGetLastError());
		}
		//*/
	}
	else
	{
		PrintFormat("%s - problem during creating buffer string[%d]", commandName, bufferSize);
	}
	return false;
}
