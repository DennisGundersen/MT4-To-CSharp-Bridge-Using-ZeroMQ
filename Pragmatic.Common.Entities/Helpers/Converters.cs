using Pragmatic.Common.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Xml.Linq;

namespace Pragmatic.Common.Entities.Helpers

{
    public static class Converters
    {
        public static bool ConvertIntToBool(int i)
        {
            bool result = false;
            if (i == 1)
            {
                result = true;
            }
            return result;
        }

        public static int ConvertBoolToInt(bool r)
        {
            int result = 0;
            if (r)
            {
                result = 1;
            }
            return result;
        }
        
        // HourglassAccountRegistrationDTO
        public static bool ArrayToHourglassAccountRegistrationDTO(string[] data, ref int currentPosition, HourglassAccountRegistrationDTO dto)
        {
            bool r = false;
            int valI = 0;
            decimal valD = 0;

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);                // 0
                if (!r) return false;
                dto.AccountNumber = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing AccountNumber", e);
            }

            try
            {
                dto.AccountName = data[currentPosition++].ToString();               // 1
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing AccountName", e);
            }

            try
            {
                dto.Symbol = data[currentPosition++].ToString();                    // 2
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing Symbol", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 3
                if (!r) return false;
                dto.TradingLotSize = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TradingLotSize", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 4
                if (!r) return false;
                dto.ExtremeTopRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ExtremeTopRate", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 5
                if (!r) return false;
                dto.NormalTopRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing NormalTopRate", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 6
                if (!r) return false;
                dto.CenterRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing CenterRate", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 7
                if (!r) return false;
                dto.NormalBottomRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing NormalBottomRate", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        //  8
                if (!r) return false;
                dto.ExtremeBottomRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ExtremeBottomRate", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 9
                if (!r) return false;
                dto.MaxPlacementDistance = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing MaxPlacementDistance", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 10
                if (!r) return false;
                dto.TestUpToRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TestUpToRate", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 11
                if (!r) return false;
                dto.TestDownToRate = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TestDownToRate", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 12
                if (!r) return false;
                dto.TestPipsUp = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TestPipsUp", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 13
                if (!r) return false;
                dto.TestPipsDown = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TestPipsDown", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 14
                if (!r) return false;
                dto.BalancerMinPlacementDistanceLongs = valI;

            }
            catch (Exception e)
            {
                throw new Exception("Error parsing BalancerMinPlacementDistanceLongs", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 15
                if (!r) return false;
                dto.BalancerMinPlacementDistanceShorts = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing BalancerMinPlacementDistanceShorts", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 16
                if (!r) return false;
                dto.LongStabilizerSizeFactor = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing LongStabilizerSizeFactor", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 17
                if (!r) return false;
                dto.ShortStabilizerSizeFactor = valI;

            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ShortStabilizerSizeFactor", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 18
                if (!r) return false;
                dto.LongBalancerSizeFactor = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing LongBalancerSizeFactor", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 19
                if (!r) return false;
                dto.ShortBalancerSizeFactor = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ShortBalancerSizeFactor", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 20
                if (!r) return false;
                dto.PrimerSizeFactor = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing PrimerSizeFactor", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 21
                if (!r) return false;
                dto.BalancerStopLossPips = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing BalancerStopLossPips", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 22
                if (!r) return false;
                dto.SecurePips = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing SecurePips", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);              // 23
                if (!r) return false;
                dto.AutoLotIncrease = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing AutoLotIncrease", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 24
                if (!r) return false;
                dto.AutoLotSafeEQLevel = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing AutoLotSafeEQLevel", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 25
                if (!r) return false;
                dto.TakeProfit = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TakeProfit", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 26
                if (!r) return false;
                dto.TradeMidTerm = ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing TradeMidTerm", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 27
                if (!r) return false;
                dto.FixedSpread = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing FixedSpread", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 28
                if (!r) return false;
                dto.ExtraLongBuffer = valI;

            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ExtraLongBuffer", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 29
                if (!r) return false;
                dto.ExtraShortBuffer = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ExtraShortBuffer", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 30
                if (!r) return false;
                dto.WarningLevel = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing WarningLevel", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 31
                if (!r) return false;
                dto.HeartbeatMonitorTimer = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing HeartbeatMonitorTimer", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 32
                if (!r) return false;
                dto.DatabaseLogTimer = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing DatabaseLogTimer", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 33
                if (!r) return false;
                dto.AutoCloseExtremes = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing AutoCloseExtremes", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 34
                if (!r) return false;
                dto.RunBalancers = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing RunBalancers", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 35
                if (!r) return false;
                dto.RunStabilizers = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing RunStabilizers", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 36
                if (!r) return false;
                dto.RunBreakouts = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing RunBreakouts", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 37
                if (!r) return false;
                dto.RunWhiplash = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing RunWhiplash", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 38
                if (!r) return false;
                dto.RunPrimers = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing RunPrimers", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 39
                if (!r) return false;
                dto.GMTOffset = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing GMTOffset", e);
            }

            try
            {
                r = decimal.TryParse(data[currentPosition++], out valD);        // 40
                if (!r) return false;
                dto.UsePoint = valD;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing UsePoint", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 41
                if (!r) return false;
                dto.RateDecimalNumbersToShow = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing RateDecimalNumbersToShow", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 42
                if (!r) return false;
                dto.IsAccountMaster = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing IsAccountMaster", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);           // 43
                if (!r) return false;
                dto.IsSymbolMaster = Helpers.Converters.ConvertIntToBool(valI);
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing IsSymbolMaster", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 44
                if (!r) return false;
                dto.ScreenshotTimer = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing ScreenshotTimer", e);
            }

            try
            {
                r = int.TryParse(data[currentPosition++], out valI);            // 45
                if (!r) return false;
                dto.MaxWeight = valI;
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing MaxWeight", e);
            }


            return true;
        }

        public static bool HourglassAccountRegistrationDTOToList(ref List<string> payload, HourglassAccountRegistrationDTO dto)
        {
            payload.Add(dto.AccountNumber.ToString());
            payload.Add(dto.AccountName.ToString());
            payload.Add(dto.Symbol.ToString());
            payload.Add(dto.TradingLotSize.ToString());
            payload.Add(dto.ExtremeTopRate.ToString());
            payload.Add(dto.NormalTopRate.ToString());
            payload.Add(dto.CenterRate.ToString());
            payload.Add(dto.NormalBottomRate.ToString());
            payload.Add(dto.ExtremeBottomRate.ToString());
            payload.Add(dto.MaxPlacementDistance.ToString());
            payload.Add(dto.TestUpToRate.ToString());
            payload.Add(dto.TestDownToRate.ToString());
            payload.Add(dto.TestPipsUp.ToString());
            payload.Add(dto.TestPipsDown.ToString());
            payload.Add(dto.BalancerMinPlacementDistanceLongs.ToString());
            payload.Add(dto.BalancerMinPlacementDistanceShorts.ToString());
            payload.Add(dto.LongStabilizerSizeFactor.ToString());
            payload.Add(dto.ShortStabilizerSizeFactor.ToString());
            payload.Add(dto.LongBalancerSizeFactor.ToString());
            payload.Add(dto.ShortBalancerSizeFactor.ToString());
            payload.Add(dto.PrimerSizeFactor.ToString());
            payload.Add(dto.BalancerStopLossPips.ToString());
            payload.Add(dto.SecurePips.ToString());

            //b = Helpers.Converters.ConvertBoolToInt(dto.AutoLotIncrease);
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.AutoLotIncrease).ToString());
            payload.Add(dto.AutoLotSafeEQLevel.ToString());
            payload.Add(dto.TakeProfit.ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.TradeMidTerm).ToString());
            payload.Add(dto.FixedSpread.ToString());
            payload.Add(dto.ExtraLongBuffer.ToString());
            payload.Add(dto.ExtraShortBuffer.ToString());
            payload.Add(dto.WarningLevel.ToString());
            payload.Add(dto.HeartbeatMonitorTimer.ToString());
            payload.Add(dto.DatabaseLogTimer.ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.AutoCloseExtremes).ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.RunBalancers).ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.RunStabilizers).ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.RunBreakouts).ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.RunWhiplash).ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.RunPrimers).ToString());
            payload.Add(dto.GMTOffset.ToString());
            payload.Add(dto.UsePoint.ToString());
            payload.Add(dto.RateDecimalNumbersToShow.ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.IsAccountMaster).ToString());
            payload.Add(Helpers.Converters.ConvertBoolToInt(dto.IsSymbolMaster).ToString());
            payload.Add(dto.ScreenshotTimer.ToString());
            payload.Add(dto.MaxWeight.ToString());

            return true;
        }


        // HourglassAccountRegistrationResultDTO
        public static bool ArrayToHourglassAccountRegistrationResultDTO(string[] data, ref int currentPosition, HourglassAccountRegistrationResultDTO dto)
        {
            // currentPosition is starting from [1], as [0] is the response code "OK"
            bool success = true;
            int valInt;
            decimal valDecimal;

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                dto.AccountId = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing AccountID", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                dto.StepGrowthFactor = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing StepGrowthFactor", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                dto.StartingBalance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing StartingBalance", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                dto.LastOrderClose = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing LastOrderClose", e);
            }
            return true;
        }

        public static List<string> HourglassAccountRegistrationResultDTOToString(HourglassAccountRegistrationResultDTO dto)
        {
            List<string> result = new List<string>();
            result.Add(dto.AccountId.ToString());   
            result.Add(dto.StepGrowthFactor.ToString());
            result.Add(dto.StartingBalance.ToString());
            result.Add(dto.StartFactor.ToString());
            result.Add(dto.LastOrderClose.ToString());

            return result;
        }

        
        // HourglassAccountStatisticsDTO
        public static bool ArrayToHourglassAccountStatisticsDTO(string[] data, ref int currentPosition, HourglassAccountStatisticsDTO result)
        {
            // currentPosition is starting from [1], as [0] is the response code "OK"
            bool success = true;
            int valInt;
            decimal valDecimal;

            // Overview
            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.Balance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing Balance", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.Equity = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing Equity", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.Longs = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing Longs", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.Shorts = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing Shorts", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.OrderCount = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing OrderCount", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.CurrentStep = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing CurrentStep", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.TradingSize = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing TradingSize", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.NextLot = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing NextLot", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.NextLotIncrease = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing NextLotIncrease", e);
            }

            // Upward
            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.UpRate = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing UpRate", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.UpEquity = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing UpEquity", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.UpBalance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing UpBalance", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.UpLongs = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing UpLongs", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.UpShorts = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing UpShorts", e);
            }


            // Top
            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.TopRate = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing TopRate", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.TopEquity = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing TopEquity", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.TopBalance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing TopBalance", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.TopLongs = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing TopLongs", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.TopShorts = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing TopShorts", e);
            }

            // Center
            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.CenterRate = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing CenterRate", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.CenterEquity = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing CenterEquity", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.CenterBalance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing CenterBalance", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.CenterLongs = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing CenterLongs", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.CenterShorts = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing CenterShorts", e);
            }

            // Downward
            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.DownRate = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing DownRate", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.DownEquity = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing DownEquity", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.DownBalance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing DownBalance", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.DownLongs = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing DownLongs", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.DownShorts = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing DownShorts", e);
            }

            // Bottom
            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.BottomRate = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing BottomRate", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.BottomEquity = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing BottomEquity", e);
            }

            try
            {
                success = decimal.TryParse(data[currentPosition++], out valDecimal);
                if (!success) return false;
                result.BottomBalance = valDecimal;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing BottomBalance", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.BottomLongs = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing BottomLongs", e);
            }

            try
            {
                success = int.TryParse(data[currentPosition++], out valInt);
                if (!success) return false;
                result.BottomShorts = valInt;
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error parsing BottomShorts", e);
            }

            return true;

        }

        public static List<string> HourglassAccountStatisticsDTOToList(HourglassAccountStatisticsDTO result)
        {
            List<string> stats = new List<string>();

            stats.Add(result.Balance.ToString());
            stats.Add(result.Equity.ToString());
            stats.Add(result.Longs.ToString());
            stats.Add(result.Shorts.ToString());
            stats.Add(result.OrderCount.ToString());
            stats.Add(result.CurrentStep.ToString());
            stats.Add(result.TradingSize.ToString());
            stats.Add(result.NextLot.ToString());
            stats.Add(result.NextLotIncrease.ToString());

            stats.Add(result.UpRate.ToString());
            stats.Add(result.UpEquity.ToString());
            stats.Add(result.UpBalance.ToString());
            stats.Add(result.UpLongs.ToString());
            stats.Add(result.UpShorts.ToString());

            stats.Add(result.TopRate.ToString());
            stats.Add(result.TopEquity.ToString());
            stats.Add(result.TopBalance.ToString());
            stats.Add(result.TopLongs.ToString());
            stats.Add(result.TopShorts.ToString());

            stats.Add(result.CenterRate.ToString());
            stats.Add(result.CenterEquity.ToString());
            stats.Add(result.CenterBalance.ToString());
            stats.Add(result.CenterLongs.ToString());
            stats.Add(result.CenterShorts.ToString());

            stats.Add(result.DownRate.ToString());
            stats.Add(result.DownEquity.ToString());
            stats.Add(result.DownBalance.ToString());
            stats.Add(result.DownLongs.ToString());
            stats.Add(result.DownShorts.ToString());

            stats.Add(result.BottomRate.ToString());
            stats.Add(result.BottomEquity.ToString());
            stats.Add(result.BottomBalance.ToString());
            stats.Add(result.BottomLongs.ToString());
            stats.Add(result.BottomShorts.ToString());

            return stats;
        }

        // ChangeOrderDTO
        public static List<string> HourglassChangeOrderDTOToList(List<ChangeOrderDTO> changeOrderItems)
        {
            List<string> result = new List<string>();
            result.Add(changeOrderItems.Count.ToString());

            foreach (var item in changeOrderItems)
            {
                result.Add(item.Ticket.ToString());
                result.Add(item.OrderType.ToString());
                result.Add(item.Lots.ToString());
                result.Add(item.OpenRate.ToString());
                result.Add(item.StopLossRate.ToString());
                result.Add(item.TakeProfitRate.ToString());
                result.Add(item.OrderFunction.ToString());
                result.Add(item.Action.ToString());
            }
            return result;
        }


        // OrderDTO
        public static List<string> HourglassOrderDTOToList(List<OrderDTO> orders)
        {
            List<string> result = new List<string>();
            result.Add(orders.Count.ToString());

            foreach (var item in orders)
            {
                result.Add(item.Ticket.ToString());
                result.Add(item.OrderType.ToString());
                result.Add(item.Lots.ToString());
                result.Add(item.OpenTime.ToString());
                result.Add(item.CloseTime.ToString());
                result.Add(item.Symbol.ToString());
                result.Add(item.OpenRate.ToString());
                result.Add(item.CloseRate.ToString());
                result.Add(item.StopLossRate.ToString());
                result.Add(item.TakeProfitRate.ToString());
                result.Add(item.Swap.ToString());   
                result.Add(item.Commission.ToString());
                result.Add(item.Profit.ToString());
                result.Add(item.Comment.ToString());
                result.Add(item.AccountId.ToString());
            }
            return result;
        }

        public static bool ArrayToHourglassOrderDTOList(string[] data, ref int currentPosition, ref List<OrderDTO> ordersList)
        {
            // Get the order count from the first element
            int orderCount = 0;
            bool r = false;
            
            int valInt;
            decimal valDecimal;
            
            // Find the amount of incoming orders
            try
            {
                r = int.TryParse(data[currentPosition++], out valInt);
                if (!r) return false;
                orderCount = valInt;                                                // 0
            }
            catch (Exception e)
            {
                throw new Exception("Error parsing Order Count", e);
            }


            // Loop through the orders
            for (int i = 0; i < orderCount; i++)
            {
                OrderDTO order = new OrderDTO();
                try
                {
                    r = int.TryParse(data[currentPosition++], out valInt);
                    if (!r) return false;
                    order.Ticket = valInt;                                        // 1
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Ticket", e);
                }

                try
                {
                    r = int.TryParse(data[currentPosition++], out valInt);
                    if (!r) return false;
                    order.OrderType = valInt;                                     // 2
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing OrderType", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.Lots = valDecimal;                                      // 3
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Lots", e);
                }

                try
                {
                    r = int.TryParse(data[currentPosition++], out valInt);
                    if (!r) return false;
                    order.OpenTime = valInt;                                      // 4
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing OpenTime", e);
                }

                try
                {
                    r = int.TryParse(data[currentPosition++], out valInt);
                    if (!r) return false;
                    order.CloseTime = valInt;                                     // 5
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing CloseTime", e);
                }

                try
                {
                    order.Symbol = data[currentPosition++];                       // 6
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Symbol", e);
                }
                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.OpenRate = valDecimal;                                  // 7
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing OpenRate", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.CloseRate = valDecimal;                                 // 8
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing CloseRate", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.StopLossRate = valDecimal;                              // 9
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing StopLossRate", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.TakeProfitRate = valDecimal;                            // 10
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing TakeProfitRate", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.Swap = valDecimal;                                      // 11
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Swap", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.Commission = valDecimal;                                // 12
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Commission", e);
                }

                try
                {
                    r = decimal.TryParse(data[currentPosition++], out valDecimal);
                    if (!r) return false;
                    order.Profit = valDecimal;                                    // 13
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Profit", e);
                }

                try
                {
                    order.Comment = data[currentPosition++];                      // 14
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing Comment", e);
                }

                try
                {
                    r = int.TryParse(data[currentPosition++], out valInt);
                    if (!r) return false;
                    order.AccountId = valInt;                                     // 15
                }
                catch (Exception e)
                {
                    throw new Exception("Error parsing AccountId", e);
                }

                ordersList.Add(order);
            }
            return true;
        }

    }
}
