//+------------------------------------------------------------------+
//|                                                         DTOs.mqh |
//|                                                 Dennis Gundersen |
//|                                  https://www.dennisgundersen.com |
//+------------------------------------------------------------------+
#property copyright "Dennis Gundersen"
#property link      "https://www.dennisgundersen.com"
#property strict

#include <CommunicationBase.mqh>

class HourglassAccountRegistrationDTO: public IZmqSerializable
{
	public:
		int accountNumber;                        // 1
		string accountName;                       // 2 NameOfAccount
      string symbol;                            // 3
      double tradingLotSize;                    // 4
      double extremeTopRate;                    // 5
      double normalTopRate;                     // 6
      double centerRate;                        // 7
      double normalBottomRate;                  // 8
      double extremeBottomRate;                 // 9
      int maxPlacementDistance;                 // 10
      double testUpToRate;                      // 11
      double testDownToRate;                    // 12
      int testPipsUp;                           // 13
      int testPipsDown;                         // 14
      int balancerMinPlacementDistanceLongs;    // 15
      int balancerMinPlacementDistanceShorts;   // 16
      int longStabilizerSizeFactor;             // 17
      int shortStabilizerSizeFactor;            // 18
      int longBalancerSizeFactor;               // 19
      int shortBalancerSizeFactor;              // 20
      int primerSizeFactor;                     // 21
      int balancerStopLossPips;                 // 22
      int securePips;                           // 23
      bool autoLotIncrease;                     // 24
      int autoLotSafeEQLevel;                   // 25
      int takeProfit;                           // 26
      bool tradeMidTerm;                        // 27
      int fixedSpread;                          // 28
      int extraLongBuffer;                      // 29
      int extraShortBuffer;                     // 30
      int warningLevel;                         // 31
      int heartbeatMonitorTimer;                // 32
      int databaseLogTimer;                     // 33
      bool autoCloseExtremes;                   // 34
      bool runBalancers;                        // 35
      bool runStabilizers;                      // 36
      bool runBreakouts;                        // 37
      bool runWhiplash;                         // 38
      bool runPrimers;                          // 39
      int gmtOffset;                            // 40
      double usePoint;                          // 41
      int rateDecimalNumbersToShow;             // 42
      bool isAccountMaster;                     // 43
      bool isSymbolMaster;                      // 44
      int screenshotTimer;                      // 45
      int maxWeight;                            // 46
      
      

		bool Serialize(string &buffer[], int &currentPosition)
		{
			buffer[++currentPosition] = IntegerToString(accountNumber);                         // 1
			buffer[++currentPosition] = accountName;                                            // 2
         buffer[++currentPosition] = symbol;                                                 // 3
         buffer[++currentPosition] = DoubleToString(tradingLotSize, 2);                      // 4
         buffer[++currentPosition] = DoubleToString(extremeTopRate, 4);                      // 5
         buffer[++currentPosition] = DoubleToString(normalTopRate, 4);                       // 6
         buffer[++currentPosition] = DoubleToString(centerRate, 4);                          // 7
         buffer[++currentPosition] = DoubleToString(normalBottomRate, 4);                    // 8
         buffer[++currentPosition] = DoubleToString(extremeBottomRate, 4);                   // 9
         buffer[++currentPosition] = IntegerToString(maxPlacementDistance);                  // 10
         buffer[++currentPosition] = DoubleToString(testUpToRate, 4);                        // 11
         buffer[++currentPosition] = DoubleToString(testDownToRate, 4);                      // 12
         buffer[++currentPosition] = IntegerToString(testPipsUp);                            // 13
         buffer[++currentPosition] = IntegerToString(testPipsDown);                          // 14
         buffer[++currentPosition] = IntegerToString(balancerMinPlacementDistanceLongs);     // 15
         buffer[++currentPosition] = IntegerToString(balancerMinPlacementDistanceShorts);    // 16
         buffer[++currentPosition] = IntegerToString(longStabilizerSizeFactor);              // 17
         buffer[++currentPosition] = IntegerToString(shortStabilizerSizeFactor);             // 18
         buffer[++currentPosition] = IntegerToString(longBalancerSizeFactor);                // 19
         buffer[++currentPosition] = IntegerToString(shortBalancerSizeFactor);               // 20
         buffer[++currentPosition] = IntegerToString(primerSizeFactor);                      // 21
         buffer[++currentPosition] = IntegerToString(balancerStopLossPips);                  // 22
         buffer[++currentPosition] = IntegerToString(securePips);                            // 23
         buffer[++currentPosition] = IntegerToString(autoLotIncrease);                       // 24
         buffer[++currentPosition] = IntegerToString(autoLotSafeEQLevel);                    // 25
         buffer[++currentPosition] = IntegerToString(takeProfit);                            // 26
         buffer[++currentPosition] = IntegerToString(tradeMidTerm);                          // 27
         buffer[++currentPosition] = IntegerToString(fixedSpread);                           // 28
         buffer[++currentPosition] = IntegerToString(extraLongBuffer);                       // 29
         buffer[++currentPosition] = IntegerToString(extraShortBuffer);                      // 30
         buffer[++currentPosition] = IntegerToString(warningLevel);                          // 31
         buffer[++currentPosition] = IntegerToString(heartbeatMonitorTimer);                 // 32
         buffer[++currentPosition] = IntegerToString(databaseLogTimer);                      // 33
         buffer[++currentPosition] = IntegerToString(autoCloseExtremes);                     // 34
         buffer[++currentPosition] = IntegerToString(runBalancers);                          // 35
         buffer[++currentPosition] = IntegerToString(runStabilizers);                        // 36
         buffer[++currentPosition] = IntegerToString(runBreakouts);                          // 37
         buffer[++currentPosition] = IntegerToString(runWhiplash);                           // 38
         buffer[++currentPosition] = IntegerToString(runPrimers);                            // 39
         buffer[++currentPosition] = IntegerToString(gmtOffset);                             // 40
         buffer[++currentPosition] = DoubleToString(usePoint, 5);                            // 41
         buffer[++currentPosition] = IntegerToString(rateDecimalNumbersToShow);              // 42
         buffer[++currentPosition] = IntegerToString(isAccountMaster);                       // 43
         buffer[++currentPosition] = IntegerToString(isSymbolMaster);                        // 44
         buffer[++currentPosition] = IntegerToString(screenshotTimer);                       // 45
         buffer[++currentPosition] = IntegerToString(maxWeight);                             // 46


			return true;
		}

		bool Deserialize(string &buffer[], int &currentPosition)
		{
			accountNumber = StringToInteger(buffer[++currentPosition]);                         // 01
			accountName = buffer[++currentPosition];                                            // 02
			symbol = buffer[++currentPosition];                                                 // 03
			tradingLotSize = StringToDouble(buffer[++currentPosition]);                         // 04
			extremeTopRate = StringToDouble(buffer[++currentPosition]);                         // 05
			normalTopRate = StringToDouble(buffer[++currentPosition]);                          // 06
			centerRate = StringToDouble(buffer[++currentPosition]);                             // 07
			normalBottomRate = StringToDouble(buffer[++currentPosition]);                       // 08
			extremeBottomRate = StringToDouble(buffer[++currentPosition]);                      // 09
			maxPlacementDistance = StringToInteger(buffer[++currentPosition]);                  // 10
			testUpToRate = StringToDouble(buffer[++currentPosition]);                           // 11
			testDownToRate = StringToDouble(buffer[++currentPosition]);                         // 12
			testPipsUp = StringToInteger(buffer[++currentPosition]);                            // 13
			testPipsDown = StringToInteger(buffer[++currentPosition]);                          // 14
			balancerMinPlacementDistanceLongs = StringToInteger(buffer[++currentPosition]);     // 15
			balancerMinPlacementDistanceShorts = StringToInteger(buffer[++currentPosition]);    // 16
			longStabilizerSizeFactor = StringToInteger(buffer[++currentPosition]);              // 17
			shortStabilizerSizeFactor = StringToInteger(buffer[++currentPosition]);             // 18
			longBalancerSizeFactor = StringToInteger(buffer[++currentPosition]);                // 19
			shortBalancerSizeFactor = StringToInteger(buffer[++currentPosition]);               // 20
			primerSizeFactor = StringToInteger(buffer[++currentPosition]);                      // 21
			balancerStopLossPips = StringToInteger(buffer[++currentPosition]);                  // 22
			securePips = StringToInteger(buffer[++currentPosition]);                            // 23
			autoLotIncrease = StringToInteger(buffer[++currentPosition]);                       // 24
			autoLotSafeEQLevel = StringToInteger(buffer[++currentPosition]);                    // 25
			takeProfit = StringToInteger(buffer[++currentPosition]);                            // 26
			tradeMidTerm = StringToInteger(buffer[++currentPosition]);                          // 27
			fixedSpread = StringToInteger(buffer[++currentPosition]);                           // 28
			extraLongBuffer = StringToInteger(buffer[++currentPosition]);                       // 29
			extraShortBuffer = StringToInteger(buffer[++currentPosition]);                      // 30
			warningLevel = StringToInteger(buffer[++currentPosition]);                          // 31
			heartbeatMonitorTimer = StringToInteger(buffer[++currentPosition]);                 // 32
			databaseLogTimer = StringToInteger(buffer[++currentPosition]);                      // 33
			autoCloseExtremes = StringToInteger(buffer[++currentPosition]);                     // 34
			runBalancers = StringToInteger(buffer[++currentPosition]);                          // 35
			runStabilizers = StringToInteger(buffer[++currentPosition]);                        // 36
			runBreakouts = StringToInteger(buffer[++currentPosition]);                          // 37
			runWhiplash = StringToInteger(buffer[++currentPosition]);                           // 38
			runPrimers = StringToInteger(buffer[++currentPosition]);                            // 39
			gmtOffset = StringToInteger(buffer[++currentPosition]);                             // 40
			usePoint = StringToDouble(buffer[++currentPosition]);                               // 41
			rateDecimalNumbersToShow = StringToInteger(buffer[++currentPosition]);              // 42
			isAccountMaster = StringToInteger(buffer[++currentPosition]);                       // 43
			isSymbolMaster = StringToInteger(buffer[++currentPosition]);                        // 44
			screenshotTimer = StringToInteger(buffer[++currentPosition]);                       // 45
			maxWeight = StringToInteger(buffer[++currentPosition]);                             // 46
			
			//serialize variables
			//variables.Deserialize(buffer, currentPosition);
			return true;
		}

		int Length()
		{
			return 46;
		}
		
		
		void Dump()
		{
			PrintFormat("HourglassAccountRegistrationDTO with AccountNumber{Id:%d} and AccountName{Id:%d} was created", accountNumber, accountName);
		}
};

class HourglassAccountRegistrationResultDTO: public IZmqSerializable
{
	public:
		int accountID;
		double stepGrowthFactor; 
		double startingBalance;  
		int startFactor;
		int lastOrderClose;

		bool Serialize(string &buffer[], int &currentPosition)
		{
			buffer[++currentPosition] = IntegerToString(accountID);
			buffer[++currentPosition] = DoubleToString(stepGrowthFactor);
			buffer[++currentPosition] = DoubleToString(startingBalance);
			buffer[++currentPosition] = IntegerToString(startFactor);
			buffer[++currentPosition] = IntegerToString(lastOrderClose);
			return true;
		}

		bool Deserialize(string &buffer[], int &currentPosition)
		{
			accountID = StringToInteger(buffer[++currentPosition]);
			stepGrowthFactor = StringToDouble(buffer[++currentPosition]);
			startingBalance = StringToDouble(buffer[++currentPosition]);
			startFactor = StringToInteger(buffer[++currentPosition]);
			lastOrderClose = StringToInteger(buffer[++currentPosition]);
			return true;
		}

		int Length()
		{
			return 5;
		}
};

class OrderDTO : public IZmqSerializable
{
	public:
		int ticket;                // 1 IntegerToString(OrderTicket())
		int orderType;             // 2 IntegerToString(OrderType())
		double lots;               // 3 DoubleToString(OrderLots(), 2)
		int openTime;              // 4 IntegerToString(OrderOpenTime()) 
		int closeTime;             // 5 IntegerToString(OrderCloseTime())
		string symbol;             // 6 Symbol() 
		double openRate;           // 7 DoubleToString(OrderOpenPrice(), rateDecimalNumbersToShow)
		double closeRate;          // 8 DoubleToString(OrderClosePrice(), rateDecimalNumbersToShow)
		double stopLossRate;       // 9 DoubleToString(OrderStopLoss(), rateDecimalNumbersToShow)
		double takeProfitRate;     // 10 DoubleToString(OrderTakeProfit(), rateDecimalNumbersToShow)
		double swap;               // 11 DoubleToString(OrderSwap(), 2)
		double commission;         // 12 DoubleToString(OrderCommission(), 2)
		double profit;             // 13 DoubleToString(OrderProfit(), 2) 
		string comment;            // 14 OrderComment()  
		int accountId;             // 15 IntegerToString(accountId)

		//#region constructors
		
		OrderDTO(const OrderDTO &that): 
			ticket(that.ticket),                   // 1
			orderType(that.orderType),             // 2
			lots(that.lots),                       // 3
			openTime(that.openTime),               // 4
			closeTime(that.closeTime),             // 5
			symbol(that.symbol),                   // 6
			openRate(that.openRate),               // 7
			closeRate(that.closeRate),             // 8
			stopLossRate(that.stopLossRate),       // 9
			takeProfitRate(that.takeProfitRate),   // 10
			swap(that.swap),                       // 11
			commission(that.commission),           // 12
			profit(that.profit),                   // 13
			comment(that.comment),                 // 14
			accountId(that.accountId)              // 15
		{}

		//this is additional for use in loop with OrderSelect to populate DTO
		OrderDTO(bool fromMQL = false, int Id = 0)
		{
			if(fromMQL)
			{
				//based on RegisterOpenOrder
				ticket = OrderTicket();
				orderType = OrderType();
				lots = OrderLots();
				openTime = OrderOpenTime();
				closeTime = OrderCloseTime();
				symbol = OrderSymbol();
				openRate = OrderOpenPrice();
				closeRate = OrderClosePrice();
				stopLossRate = OrderStopLoss();
				takeProfitRate = OrderTakeProfit();
				swap = OrderSwap();
				commission = OrderCommission();
				profit = OrderProfit();
				comment = OrderComment();
				accountId = Id;
			}
		}
		//#endregion constructors

		void Dump()
		{
			PrintFormat("Ticket{Id:%d}", ticket);
		}

		void MockThis(int j)
		{
		   PrintFormat("Running MockThis(%d)", j);
			ticket = 123456;
			orderType = 1;
			lots = 0.01;
			openTime = 321654;
			closeTime = 0;
			symbol = "USDCAD";
			openRate = 1.3501;
			closeRate = 1.3550;
			stopLossRate = 0;
			takeProfitRate = 1.3550;
			swap = 0.37;
			commission = 0.5 + j * 0.1;
			profit = ticket * 2.34;
			comment = StringConcatenate("Mocked #", j);
			accountId = 99;
         /*
			PrintFormat("Result: %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)",
			            IntegerToString(ticket), 
			            IntegerToString(orderType),
			            DoubleToString(lots, 2),
			            IntegerToString(openTime),
			            IntegerToString(closeTime),
			            symbol,
			            DoubleToString(openRate, 4),
			            DoubleToString(closeRate, 4),
			            DoubleToString(stopLossRate, 4),
			            DoubleToString(takeProfitRate, 4),
			            DoubleToString(swap, 2),
			            DoubleToString(commission, 2),
			            DoubleToString(profit, 2),
			            comment,
			            IntegerToString(accountId)
			            );
		   */
		}

		//interface implementation
		bool Serialize(string& buffer[], int& currentPosition)
		{
			//optional: we could add check that buffer is enough or even dynamically resize buffer
			//order must be the same as in C# version
			buffer[++currentPosition] = IntegerToString(ticket);
			buffer[++currentPosition] = IntegerToString(orderType);
			buffer[++currentPosition] = DoubleToString(lots);
			buffer[++currentPosition] = IntegerToString(openTime); 
			buffer[++currentPosition] = IntegerToString(closeTime); 
			buffer[++currentPosition] = symbol; 
			buffer[++currentPosition] = DoubleToString(openRate); 
			buffer[++currentPosition] = DoubleToString(closeRate); 
			buffer[++currentPosition] = DoubleToString(stopLossRate);
			buffer[++currentPosition] = DoubleToString(takeProfitRate);
			buffer[++currentPosition] = DoubleToString(swap);
			buffer[++currentPosition] = DoubleToString(commission); 
			buffer[++currentPosition] = DoubleToString(profit); 
			buffer[++currentPosition] = comment;  
			buffer[++currentPosition] = IntegerToString(accountId);
			return true;
		}

		bool Deserialize(string& buffer[], int& currentPosition)
		{
			ticket = StringToInteger(buffer[++currentPosition]);
			orderType = StringToInteger(buffer[++currentPosition]);
			lots = StringToDouble(buffer[++currentPosition]);
			openTime = StringToInteger(buffer[++currentPosition]); 
			closeTime = StringToInteger(buffer[++currentPosition]);
			symbol = buffer[++currentPosition]; 
			openRate = StringToDouble(buffer[++currentPosition]); 
			closeRate = StringToDouble(buffer[++currentPosition]); 
			stopLossRate = StringToDouble(buffer[++currentPosition]);
			takeProfitRate = StringToDouble(buffer[++currentPosition]);
			swap = StringToDouble(buffer[++currentPosition]);
			commission = StringToDouble(buffer[++currentPosition]); 
			profit = StringToDouble(buffer[++currentPosition]); 
			comment = buffer[++currentPosition];  
			accountId = StringToInteger(buffer[++currentPosition]);
			return true;
		}

		//returns number of serialized fields - used for reducing array resized - buffer array size can be computed
		int Length()
		{
			return 15;
		}
};


class ChangeOrderDTO : public IZmqSerializable
{
	public:
		int ticket;             // 1
		int orderType;          // 2
		double lots;            // 3
		double openRate;        // 4
		double stopLossRate;    // 5
		double takeProfitRate;  // 6
		int function;           // 7 None = 0, RegularLong = 1, RegularShort = 2, BalancerLong = 3, BalancerShort = 4, BreakoutLong = 5, BreakoutShort = 6  
		int action;             // 8 None = 0, Add = 1, Modify = 2, Close = 3


		void Dump()
		{
			PrintFormat("OrderChange{ticket:%d, function:%d, action:%d}", ticket, function, action);
		}

		//interface implementation
		bool Serialize(string& buffer[], int& currentPosition)
		{
			//optional: we could add check that buffer is enough or even dynamically resize buffer
			//order must be the same as in C# version
			buffer[++currentPosition] = IntegerToString(ticket);
			buffer[++currentPosition] = IntegerToString(orderType);
			buffer[++currentPosition] = DoubleToString(lots);
			buffer[++currentPosition] = DoubleToString(openRate); 
			buffer[++currentPosition] = DoubleToString(stopLossRate);
			buffer[++currentPosition] = DoubleToString(takeProfitRate);
			buffer[++currentPosition] = IntegerToString(function);
			buffer[++currentPosition] = IntegerToString(action);
			return true;
		}

		bool Deserialize(string& buffer[], int& currentPosition)
		{
			ticket = StringToInteger(buffer[++currentPosition]);
			orderType = StringToInteger(buffer[++currentPosition]);
			lots = StringToDouble(buffer[++currentPosition]);
			openRate = StringToDouble(buffer[++currentPosition]); 
			stopLossRate = StringToDouble(buffer[++currentPosition]);
			takeProfitRate = StringToDouble(buffer[++currentPosition]);
			function = StringToInteger(buffer[++currentPosition]);
			action = StringToInteger(buffer[++currentPosition]);
			return true;
		}

		//returns number of serialized fields - used for reducing array resized - buffer array size can be computed
		int Length()
		{
			return 8;
		}
};

class HourglassAccountOverviewDTO: public IZmqSerializable
{
	public:
		double Balance;            // 1
		double Equity;             // 2
      double Longs;              // 3
      double Shorts;             // 4
		int OrderCount;            // 5
		int CurrentStep;           // 6
		double TradingSize;        // 7
		double NextLot;            // 8
		double NextLotIncrease;    // 9
		
		// Upwards
		double UpRate;             // 10
		double UpEquity;           // 11
		double UpBalance;          // 12
		double UpLongs;            // 13
		double UpShorts;           // 14
		
		// Top
		double TopRate;            // 15
		double TopEquity;          // 16
		double TopBalance;         // 17
		double TopLongs;           // 18
		double TopShorts;          // 19
		
      // Center
		double CenterRate;         // 20
		double CenterEquity;       // 21
		double CenterBalance;      // 22
		double CenterLongs;        // 23
		double CenterShorts;       // 24

		// Downwards
		double DownRate;           // 25
		double DownEquity;         // 26
		double DownBalance;        // 27
		double DownLongs;          // 28
		double DownShorts;         // 29

		// Bottom
		double BottomRate;         // 30
		double BottomEquity;       // 31
		double BottomBalance;      // 32
		double BottomLongs;        // 33
		double BottomShorts;       // 34


		bool Serialize(string &buffer[], int &currentPosition)
		{
			buffer[++currentPosition] = DoubleToString(Balance);           // 1
			buffer[++currentPosition] = DoubleToString(Equity);            // 2
			buffer[++currentPosition] = DoubleToString(Longs);             // 3
			buffer[++currentPosition] = DoubleToString(Shorts);            // 4 
			buffer[++currentPosition] = IntegerToString(OrderCount);       // 5
			buffer[++currentPosition] = IntegerToString(CurrentStep);      // 6
			buffer[++currentPosition] = DoubleToString(TradingSize);       // 7
			buffer[++currentPosition] = DoubleToString(NextLot);           // 8 
			buffer[++currentPosition] = DoubleToString(NextLotIncrease);   // 9
			// Upwards
			buffer[++currentPosition] = DoubleToString(UpRate);            // 10
			buffer[++currentPosition] = DoubleToString(UpEquity);          // 11
			buffer[++currentPosition] = DoubleToString(UpBalance);         // 12
			buffer[++currentPosition] = DoubleToString(UpLongs);           // 13
			buffer[++currentPosition] = DoubleToString(UpShorts);          // 14
			// Upwards
			buffer[++currentPosition] = DoubleToString(TopRate);           // 15
			buffer[++currentPosition] = DoubleToString(TopEquity);         // 16
			buffer[++currentPosition] = DoubleToString(TopBalance);        // 17
			buffer[++currentPosition] = DoubleToString(TopLongs);          // 18
			buffer[++currentPosition] = DoubleToString(TopShorts);         // 19
			// Upwards
			buffer[++currentPosition] = DoubleToString(CenterRate);        // 20
			buffer[++currentPosition] = DoubleToString(CenterEquity);      // 21
			buffer[++currentPosition] = DoubleToString(CenterBalance);     // 22
			buffer[++currentPosition] = DoubleToString(CenterLongs);       // 23
			buffer[++currentPosition] = DoubleToString(CenterShorts);      // 24
			// Downwards
			buffer[++currentPosition] = DoubleToString(DownRate);          // 25
			buffer[++currentPosition] = DoubleToString(DownEquity);        // 26
			buffer[++currentPosition] = DoubleToString(DownBalance);       // 27
			buffer[++currentPosition] = DoubleToString(DownLongs);         // 28
			buffer[++currentPosition] = DoubleToString(DownShorts);        // 29
			// Bottom
			buffer[++currentPosition] = DoubleToString(BottomRate);        // 30
			buffer[++currentPosition] = DoubleToString(BottomEquity);      // 31
			buffer[++currentPosition] = DoubleToString(BottomBalance);     // 32
			buffer[++currentPosition] = DoubleToString(BottomLongs);       // 33
			buffer[++currentPosition] = DoubleToString(BottomShorts);      // 34
			
			
			
			
			return true;
		}

		bool Deserialize(string &buffer[], int &currentPosition)
		{
			Balance = StringToDouble(buffer[++currentPosition]);           // 1
			Equity = StringToDouble(buffer[++currentPosition]);            // 2
			Longs = StringToDouble(buffer[++currentPosition]);             // 3
			Shorts = StringToDouble(buffer[++currentPosition]);            // 4
			OrderCount = StringToInteger(buffer[++currentPosition]);       // 5
			CurrentStep = StringToInteger(buffer[++currentPosition]);      // 6
			TradingSize = StringToDouble(buffer[++currentPosition]);       // 7
			NextLot = StringToDouble(buffer[++currentPosition]);           // 8
			NextLotIncrease = StringToDouble(buffer[++currentPosition]);   // 9
			// Upwards
			UpRate = StringToDouble(buffer[++currentPosition]);            // 10
			UpEquity = StringToDouble(buffer[++currentPosition]);          // 11
			UpBalance = StringToDouble(buffer[++currentPosition]);         // 12
			UpLongs = StringToDouble(buffer[++currentPosition]);           // 13
			UpShorts = StringToDouble(buffer[++currentPosition]);          // 14
			// Top
			TopRate = StringToDouble(buffer[++currentPosition]);           // 15
			TopEquity = StringToDouble(buffer[++currentPosition]);         // 16
			TopBalance = StringToDouble(buffer[++currentPosition]);        // 17
			TopLongs = StringToDouble(buffer[++currentPosition]);          // 18
			TopShorts = StringToDouble(buffer[++currentPosition]);         // 19
			// Center
			CenterRate = StringToDouble(buffer[++currentPosition]);        // 20
			CenterEquity = StringToDouble(buffer[++currentPosition]);      // 21
			CenterBalance = StringToDouble(buffer[++currentPosition]);     // 22
			CenterLongs = StringToDouble(buffer[++currentPosition]);       // 23
			CenterShorts = StringToDouble(buffer[++currentPosition]);      // 24
			// Down
			DownRate = StringToDouble(buffer[++currentPosition]);          // 25
			DownEquity = StringToDouble(buffer[++currentPosition]);        // 26
			DownBalance = StringToDouble(buffer[++currentPosition]);       // 27
			DownLongs = StringToDouble(buffer[++currentPosition]);         // 28
			DownShorts = StringToDouble(buffer[++currentPosition]);        // 29
			// Bottom
			BottomRate = StringToDouble(buffer[++currentPosition]);        // 30
			BottomEquity = StringToDouble(buffer[++currentPosition]);      // 31
			BottomBalance = StringToDouble(buffer[++currentPosition]);     // 32
			BottomLongs = StringToDouble(buffer[++currentPosition]);       // 33
			BottomShorts = StringToDouble(buffer[++currentPosition]);      // 34
			
			return true;
		}

		int Length()
		{
			return 34;
		}
};