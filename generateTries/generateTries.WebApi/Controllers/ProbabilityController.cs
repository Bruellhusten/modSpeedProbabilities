using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using generateTries.Application;
using generateTries.Domain;

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
            return Chances.CalculateSingle(speed);
        }

        [HttpGet("GetCumulatedProbabilitiesForSpeed")]
        public decimal GetCumulatedProbabilitiesForSpeed(int speed)
        {
            CheckSpeedInput(speed);
            return Chances.CalculateMany(speed);
        }

        [HttpPost("EvaluateStrategy")]
        public string EvaluateStrategy(Strategy strategy, int days)         
        {
            CheckStrategy(strategy);
            return StrategyOutput(strategy); //ToDo: Implement evaluation
        }

        private string StrategyOutput(Strategy strategy)
        {
            return "===Your Strategy===" + Environment.NewLine +
                "Grey: " + strategy.GreyThreshold.ToString() + Environment.NewLine + 
                "Green: " + strategy.GreenThreshold.ToString() + Environment.NewLine +
                "Blue: " + strategy.BlueThreshold.ToString() + Environment.NewLine +
                "Purple: " + strategy.PurpleThreshold.ToString() + Environment.NewLine +
                "> Daily Ship Energy: " + strategy.DailyShipEnergy.ToString() + Environment.NewLine +
                "> Daily Crystal for Slicing Mats: " + strategy.DailySlicingCrystal.ToString();
        }

        private void CheckSpeedInput(int speed)
        {
            if (!IsSpeedValid(speed))
            {
                throw new ArgumentException("Use speeds between 3 and 29");
            }
        }

        private void CheckStrategy(Strategy strategy)
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