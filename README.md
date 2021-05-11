# Mod Speed Probabilities

This is a small webservice I created mostly for the purpose of evaluating probabilities for mod slicing in Star Wars Galaxy of Heroes. 
To run it, you need at least a .net Core 2.2 runtime. It creates a website hosted on your machine that you can open with https://localhost:Portnumber/index.html
The service is based on statistics taken from the Planet Coruscant Discord server. (chances for hitting certain speeds, chances for hitting 4 dot mods etc.)

There are 3 endpoints in it currently: 
1. GetProbabilityForSpeed: Gets the exact probability for hitting a mod with a certain speed => +20 speed gets you just the +20 speed probability, not the >= +20 speed one
2. GetCumulatedProbabilitiesForSpeed: This endpoint cumulates speeds. "20" means you will be returned the probability in decimal for mods getting >= +20 speed.
3. EvaluateStrategy: This endpoint takes the slicing thresholds you use and the energy/crystal you put into mod farming and simulates the yield of speed mods for a time period you can specify.
There is a bug in this endpoint though, so the numbers aren't precise. I believe the bug is somewhere along the "discard failed slices"-logics, but I could not find it yet. This means the numbers displayed are a bit higher than the actual numbers, but you can still use it to test the effect of speed thresholds. As in how much your yields of >= +20 speed mods will go down if you lower the thresholds.
