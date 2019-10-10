using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using generateTries.Application;
using generateTries.Domain;
using System.Globalization;

namespace generateTries.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProbabilityController : ControllerBase
    {
        [HttpGet("GetProbabilityForSpeed")]
        public decimal GetProbabilityForSpeed(int speed)
        {
            CheckSpeedInput(speed);
            return new Chances().CalculateSingle(speed);
        }

        [HttpGet("GetCumulatedProbabilitiesForSpeed")]
        public decimal GetCumulatedProbabilitiesForSpeed(int speed)
        {
            CheckSpeedInput(speed);
            return new Chances().CalculateMany(speed);
        }

        [HttpPost("EvaluateStrategy")]
        public string EvaluateStrategy(StrategyDTO strategyDTO)         
        {
            CheckStrategy(strategyDTO);
            var strategy = new Strategy(strategyDTO);
            var evaluation = strategy.EvaluateStrategy();
            return StrategyOutput(strategyDTO, evaluation); //ToDo: Implement evaluation
        }

        private string StrategyOutput(StrategyDTO strategy, StrategyResult evaluation)
        {
            return "===Your Strategy===" + Environment.NewLine +
                "Grey: " + strategy.GreyThreshold.ToString() + Environment.NewLine + 
                "Green: " + strategy.GreenThreshold.ToString() + Environment.NewLine +
                "Blue: " + strategy.BlueThreshold.ToString() + Environment.NewLine +
                "Purple: " + strategy.PurpleThreshold.ToString() + Environment.NewLine +
                "> Daily Mod Energy: " + strategy.DailyModEnergy.ToString() + Environment.NewLine +
                "> Daily Crystal for Slicing Mats: " + strategy.DailySlicingCrystal.ToString() + Environment.NewLine +
                "=========================================" + Environment.NewLine +
                "Will yield after " + evaluation.PassedDays.ToString() + " days these Speed Mods:" + Environment.NewLine +
                "+10 Speed: " + Math.Round(evaluation.SumOfPlus10Mods, 4).ToString(CultureInfo.InvariantCulture) + Environment.NewLine +
                "+15 Speed: " + Math.Round(evaluation.SumOfPlus15Mods, 4).ToString() + Environment.NewLine +
                "+20 Speed: " + Math.Round(evaluation.SumOfPlus20Mods, 4).ToString() + Environment.NewLine +
                "+25 Speed: " + Math.Round(evaluation.SumOfPlus25Mods, 4).ToString();
        }

        private void CheckSpeedInput(int speed)
        {
            if (!IsSpeedValid(speed))
            {
                throw new ArgumentException("Use speeds between 3 and 29");
            }
        }

        private void CheckStrategy(StrategyDTO strategy)
        {
            if(!(IsSpeedValid(strategy.GreyThreshold)
                && IsSpeedValid(strategy.GreenThreshold)
                && IsSpeedValid(strategy.BlueThreshold)
                && IsSpeedValid(strategy.PurpleThreshold)))
            {
                throw new ArgumentException("Use speeds between 3 and 29");
            }
        }

        private bool IsSpeedValid(int speed) => speed >= 3 && speed <= 29;
    }
}