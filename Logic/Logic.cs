using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
using Models.DataTransfer;
using Repository;


namespace Service
{
    public class Logic
    {
        public Logic() { }
        public Logic(Repo repo, ILogger<Repo> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        private readonly Repo _repo;
        private readonly ILogger<Repo> _logger;

        /******************************************************************************************
         * What we can do:
         *      Create empty statistic
         *      Get statistic by guid
         *      Get player's overall statistics
         *      Update statistics for a particular game
         *      Delete statistic from the database
         *      
         * TODO:
         *      Send appropriate Dto's back based on frontend needs -- need to meet with Ryan
         *
         *****************************************************************************************/

        public async Task BuildPlayerGame(string playerId, Guid gameId, Guid statLineId)
        {
            PlayerGame playerGame = new PlayerGame()
            {
                UserID = playerId,
                GameID = gameId,
                StatLineID = statLineId
            };

            await _repo.PlayerGames.AddAsync(playerGame);
            await _repo.CommitSave();
        }

        public async Task BuildTeamGame(Guid teamId, Guid gameId, Guid statLineId)
        {
            TeamGame teamGame = new TeamGame()
            {
                TeamID = teamId,
                GameID = gameId,
                StatLineID = statLineId
            };

            await _repo.TeamGames.AddAsync(teamGame);
            await _repo.CommitSave();
        }

        // CreateStatistic
        /// <summary>
        /// Creates a basketball statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> CreateStatistic(string playerId, Guid gameId, BasketballStatistic basketballStatistic)
        {
            await BuildPlayerGame(playerId, gameId, basketballStatistic.StatLineID);
            return await _repo.CreateStatistic(basketballStatistic);
        }

        /// Creates a baseball statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PlayerGameStatDto> CreateStatistic(string playerId, Guid gameId, BaseballStatistic baseballStatistic)
        {
            baseballStatistic = await _repo.CreateStatistic(baseballStatistic);
            await BuildPlayerGame(playerId, gameId, baseballStatistic.StatLineID);
            PlayerGameStatDto pgs = new PlayerGameStatDto { playerId = playerId, gameId = gameId, baseballStat = baseballStatistic };
            return pgs;
        }

        /// Creates a football statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> CreateStatistic(string playerId, Guid gameId, FootBallStatistic footballStatistic)
        {
            await BuildPlayerGame(playerId, gameId, footballStatistic.StatLineID);
            return await _repo.CreateStatistic(footballStatistic);
        }

        /// Creates a golf statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> CreateStatistic(string playerId, Guid gameId, GolfStatistic golfStatistic)
        {
            await BuildPlayerGame(playerId, gameId, golfStatistic.StatLineID);
            return await _repo.CreateStatistic(golfStatistic);
        }

        /// Creates a hockey statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> CreateStatistic(string playerId, Guid gameId, HockeyStatistic hockeyStatistic)
        {
            await BuildPlayerGame(playerId, gameId, hockeyStatistic.StatLineID);
            return await _repo.CreateStatistic(hockeyStatistic);
        }

        /// Creates a soccer statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> CreateStatistic(string playerId, Guid gameId, SoccerStatistic soccerStatistic)
        {
            await BuildPlayerGame(playerId, gameId, soccerStatistic.StatLineID);
            return await _repo.CreateStatistic(soccerStatistic);
        }


        /*****************************************************************************************/


        // CreateTeamStatistic
        /// <summary>
        /// Creates a basketball statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> CreateTeamStatistic(Guid teamId, Guid gameId, BasketballStatistic basketballStatistic)
        {
            await BuildTeamGame(teamId, gameId, basketballStatistic.StatLineID);
            return await _repo.CreateStatistic(basketballStatistic);
        }

        /// <summary>
        /// Creates a baseball statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> CreateTeamStatistic(Guid teamId, Guid gameId, BaseballStatistic baseballStatistic)
        {
            await BuildTeamGame(teamId, gameId, baseballStatistic.StatLineID);
            return await _repo.CreateStatistic(baseballStatistic);
        }

        /// <summary>
        /// Creates a football statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> CreateTeamStatistic(Guid teamId, Guid gameId, FootBallStatistic footballStatistic)
        {
            await BuildTeamGame(teamId, gameId, footballStatistic.StatLineID);
            return await _repo.CreateStatistic(footballStatistic);
        }

        /// <summary>
        /// Creates a golf statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> CreateTeamStatistic(Guid teamId, Guid gameId, GolfStatistic golfStatistic)
        {
            await BuildTeamGame(teamId, gameId, golfStatistic.StatLineID);
            return await _repo.CreateStatistic(golfStatistic);
        }

        /// <summary>
        /// Creates a hockey statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> CreateTeamStatistic(Guid teamId, Guid gameId, HockeyStatistic hockeyStatistic)
        {
            await BuildTeamGame(teamId, gameId, hockeyStatistic.StatLineID);
            return await _repo.CreateStatistic(hockeyStatistic);
        }

        /// <summary>
        /// Creates a  statistic for a player. Statistic can be updated with
        /// UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> CreateTeamStatistic(Guid teamId, Guid gameId, SoccerStatistic soccerStatistic)
        {
            await BuildTeamGame(teamId, gameId, soccerStatistic.StatLineID);
            return await _repo.CreateStatistic(soccerStatistic);
        }


        /*****************************************************************************************/


        // GetSportStatisticById
        /// <summary>
        /// Takes an id and retrieves matching specified basketball statistic for a team or an 
        /// individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetBasketballStatisticById(Guid id){
            return await _repo.GetBasketballStatisticsById(id);
        }

        /// <summary>
        /// Takes an id and retrieves matching specified baseball statistic for a team or an 
        /// individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> GetBaseballStatisticById(Guid id)
        {
            return await _repo.GetBaseballStatisticsById(id);
        }

        /// <summary>
        /// Takes an id and retrieves matching specified football statistic for a team or an 
        /// individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> GetFootballStatisticById(Guid id)
        {
            return await _repo.GetFootballStatisticsById(id);
        }

        /// <summary>
        /// Takes an id and retrieves matching specified golf statistic for a team or an 
        /// individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> GetGolfStatisticById(Guid id)
        {
            return await _repo.GetGolfStatisticsById(id);
        }

        /// <summary>
        /// Takes an id and retrieves matching specified hockey statistic for a team or an 
        /// individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> GetHockeyStatisticById(Guid id)
        {
            return await _repo.GetHockeyStatisticsById(id);
        }

        /// <summary>
        /// Takes an id and retrieves matching specified baseball statistic for a team or an 
        /// individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> GetSoccerStatisticById(Guid id)
        {
            return await _repo.GetSoccerStatisticsById(id);
        }


        /*****************************************************************************************/


        // GetSportGameStatistic
        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetBasketballGameStatistic(string userId, Guid gameId)
        {
            return await _repo.GetBasketballGameStatistic(userId, gameId);
        }

        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> GetBaseballGameStatistic(string userId, Guid gameId)
        {
            return await _repo.GetBaseballGameStatistic(userId, gameId);
        }

        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> GetFootballGameStatistic(string userId, Guid gameId)
        {
            return await _repo.GetFootballGameStatistic(userId, gameId);
        }

        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> GetGolfGameStatistic(string userId, Guid gameId)
        {
            return await _repo.GetGolfGameStatistic(userId, gameId);
        }

        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> GetHockeyGameStatistic(string userId, Guid gameId)
        {
            return await _repo.GetHockeyGameStatistic(userId, gameId);
        }

        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> GetSoccerGameStatistic(string userId, Guid gameId)
        {
            return await _repo.GetSoccerGameStatistic(userId, gameId);
        }


        /*****************************************************************************************/


        // GetSportGameStatistic
        /// <summary>
        /// Takes a game id and a team id  to retrieve statline from TeamGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetBasketballGameStatistic(Guid teamId, Guid gameId)
        {
            return await _repo.GetBasketballGameStatistic(teamId, gameId);
        }

        /// <summary>
        /// Takes a game id and a team id  to retrieve statline from TeamGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> GetBaseballGameStatistic(Guid teamId, Guid gameId)
        {
            return await _repo.GetBaseballGameStatistic(teamId, gameId);
        }

        /// <summary>
        /// Takes a game id and a team id  to retrieve statline from TeamGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> GetFootballGameStatistic(Guid teamId, Guid gameId)
        {
            return await _repo.GetFootballGameStatistic(teamId, gameId);
        }

        /// <summary>
        /// Takes a game id and a team id  to retrieve statline from TeamGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> GetGolfGameStatistic(Guid teamId, Guid gameId)
        {
            return await _repo.GetGolfGameStatistic(teamId, gameId);
        }

        /// <summary>
        /// Takes a game id and a team id  to retrieve statline from TeamGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> GetHockeyGameStatistic(Guid teamId, Guid gameId)
        {
            return await _repo.GetHockeyGameStatistic(teamId, gameId);
        }

        /// <summary>
        /// Takes a game id and a team id  to retrieve statline from TeamGame db set. Returns 
        /// stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> GetSoccerGameStatistic(Guid teamId, Guid gameId)
        {
            return await _repo.GetSoccerGameStatistic(teamId, gameId);
        }


        /*****************************************************************************************/


        // GetPlayerOverallSportStatistic
        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetPlayerOverallBasketballStatistic(string id)
        {
            // create basketball statistic to return
            BasketballStatistic basketballStatistic = new BasketballStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<BasketballStatistic> basketballStatisticList = await _repo.GetBasketballStatisticByPlayerId(id);
            // add all stats together
            foreach(BasketballStatistic b in basketballStatisticList)
            {
                basketballStatistic.Assists += b.Assists;
                basketballStatistic.FGoals += b.FGoals;
                basketballStatistic.Fouls += b.Fouls;
                basketballStatistic.FThrows += b.FThrows;
                basketballStatistic.Rebounds += b.Rebounds;
                basketballStatistic.Steals += b.Steals;
                basketballStatistic.Turnovers += b.Turnovers;
                basketballStatistic.ThreePts += b.ThreePts;
                basketballStatistic.PossessionTime += b.PossessionTime;
            }
            // return total
            return basketballStatistic;
        }

        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> GetPlayerOverallBaseballStatistic(string id)
        {
            // create baseball statistic to return
            BaseballStatistic baseballStatistic = new BaseballStatistic();

            // get list of all stats with userId filtering result
            IEnumerable<BaseballStatistic> baseballStatisticEnumerable = await _repo.GetBaseballStatisticByPlayerId(id);
            List<BaseballStatistic> baseballStatisticList = new List<BaseballStatistic>();

            // add all stats together
            foreach (BaseballStatistic b in baseballStatisticEnumerable)
            {
                baseballStatistic.BattingAve += b.BattingAve;
                baseballStatistic.ERA += b.ERA;
                baseballStatistic.Hits += b.Hits;
                baseballStatistic.RBI += b.RBI;
                baseballStatistic.Runs += b.Runs;
                baseballStatistic.Saves += b.Saves;
                baseballStatistic.Steals += b.Steals;
                baseballStatistic.StrikeOuts += b.StrikeOuts;
                baseballStatisticList.Add(b);
            }

            // correcting averages
            baseballStatistic.BattingAve /= baseballStatisticList.Count;
            baseballStatistic.ERA /= baseballStatisticList.Count;

            // return total
            return baseballStatistic;
        }

        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> GetPlayerOverallFootballStatistic(string id)
        {
            // create football statistic to return
            FootBallStatistic footballStatistic = new FootBallStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<FootBallStatistic> footballStatisticList = await _repo.GetFootballStatisticByPlayerId(id);
            // add all stats together
            foreach (FootBallStatistic f in footballStatisticList)
            {
                footballStatistic.FirstDownCons += f.FirstDownCons;
                footballStatistic.Penalties += f.Penalties;
                footballStatistic.Plays += f.Plays;
                footballStatistic.PossessionTime += f.PossessionTime;
                footballStatistic.Sacks += f.Sacks;
                footballStatistic.Turnovers += f.Turnovers;
                footballStatistic.YardsRec += f.YardsRec;
                footballStatistic.YardsRun += f.YardsRun;
            }
            // return total
            return footballStatistic;
        }

        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> GetPlayerOverallGolfStatistic(string id)
        {
            // create golf statistic to return
            GolfStatistic golfStatistic = new GolfStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<GolfStatistic> golfStatisticList = await _repo.GetGolfStatisticByPlayerId(id);
            // add all stats together
            foreach (GolfStatistic g in golfStatisticList)
            {
                golfStatistic.Birdies += g.Birdies;
                golfStatistic.Bogeys += g.Bogeys;
                golfStatistic.DriveAccuracy += g.DriveAccuracy;
                golfStatistic.DriveDistance += g.DriveDistance;
                golfStatistic.Eagles += g.Eagles;
                golfStatistic.GIR += g.GIR;
                golfStatistic.PutsperGIR += g.PutsperGIR;
                golfStatistic.SandSaves += g.SandSaves;
                golfStatistic.ScoreToPar += g.ScoreToPar;
                golfStatistic.Scrambles += g.Scrambles;
            }
            // return total
            return golfStatistic;
        }

        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> GetPlayerOverallHockeyStatistic(string id)
        {
            // create hockey statistic to return
            HockeyStatistic hockeyStatistic = new HockeyStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<HockeyStatistic> hockeyStatisticList = await _repo.GetHockeyStatisticByPlayerId(id);
            // add all stats together
            foreach (HockeyStatistic h in hockeyStatisticList)
            {
                hockeyStatistic.Blocks += h.Blocks;
                hockeyStatistic.FaceOffWins += h.FaceOffWins;
                hockeyStatistic.GiveAways += h.GiveAways;
                hockeyStatistic.Goals += h.Goals;
                hockeyStatistic.Hits += h.Hits;
                hockeyStatistic.PenaltyMins += h.PenaltyMins;
                hockeyStatistic.PowerPlayOpps += h.PowerPlayOpps;
                hockeyStatistic.Shots += h.Shots;
                hockeyStatistic.TakeAWays += h.TakeAWays;
            }
            // return total
            return hockeyStatistic;
        }

        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> GetPlayerOverallSoccerStatistic(string id)
        {
            // create soccer statistic to return
            SoccerStatistic soccerStatistic = new SoccerStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<SoccerStatistic> soccerStatisticList = await _repo.GetSoccerStatisticByPlayerId(id);
            // add all stats together
            foreach (SoccerStatistic s in soccerStatisticList)
            {
                soccerStatistic.CornerKicks += s.CornerKicks;
                soccerStatistic.Fouls += s.Fouls;
                soccerStatistic.Goals += s.Goals;
                soccerStatistic.OffSides += s.OffSides;
                soccerStatistic.PossessionTime += s.PossessionTime;
                soccerStatistic.RedCards += s.RedCards;
                soccerStatistic.ShotOnGoal += s.ShotOnGoal;
                soccerStatistic.yellowCards += s.yellowCards;
            }
            // return total
            return soccerStatistic;
        }


        /*****************************************************************************************/


        // GetTeamOverallSportStatistic
        /// <summary>
        /// Summarizes team statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetTeamOverallBasketballStatistic(Guid id)
        {
            // create basketball statistic to return
            BasketballStatistic basketballStatistic = new BasketballStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<BasketballStatistic> basketballStatisticList = await _repo.GetBasketballStatisticByTeamId(id);
            // add all stats together
            foreach (BasketballStatistic b in basketballStatisticList)
            {
                basketballStatistic.Assists += b.Assists;
                basketballStatistic.FGoals += b.FGoals;
                basketballStatistic.Fouls += b.Fouls;
                basketballStatistic.FThrows += b.FThrows;
                basketballStatistic.Rebounds += b.Rebounds;
                basketballStatistic.Steals += b.Steals;
                basketballStatistic.Turnovers += b.Turnovers;
                basketballStatistic.ThreePts += b.ThreePts;
                basketballStatistic.PossessionTime += b.PossessionTime;
            }
            // return total
            return basketballStatistic;
        }

        /// <summary>
        /// Summarizes team statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> GetTeamOverallBaseballStatistic(Guid id)
        {
            // create baseball statistic to return
            BaseballStatistic baseballStatistic = new BaseballStatistic();

            // get list of all stats with userId filtering result
            IEnumerable<BaseballStatistic> baseballStatisticEnumerable = await _repo.GetBaseballStatisticByTeamId(id);
            List<BaseballStatistic> baseballStatisticList = new List<BaseballStatistic>();

            // add all stats together
            foreach (BaseballStatistic b in baseballStatisticEnumerable)
            {
                baseballStatistic.BattingAve += b.BattingAve;
                baseballStatistic.ERA += b.ERA;
                baseballStatistic.Hits += b.Hits;
                baseballStatistic.RBI += b.RBI;
                baseballStatistic.Runs += b.Runs;
                baseballStatistic.Saves += b.Saves;
                baseballStatistic.Steals += b.Steals;
                baseballStatistic.StrikeOuts += b.StrikeOuts;
                baseballStatisticList.Add(b);
            }

            // correcting averages
            baseballStatistic.BattingAve /= baseballStatisticList.Count;
            baseballStatistic.ERA /= baseballStatisticList.Count;

            // return total
            return baseballStatistic;
        }

        /// <summary>
        /// Summarizes team statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> GetTeamOverallFootballStatistic(Guid id)
        {
            // create football statistic to return
            FootBallStatistic footballStatistic = new FootBallStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<FootBallStatistic> footballStatisticList = await _repo.GetFootballStatisticByTeamId(id);
            // add all stats together
            foreach (FootBallStatistic f in footballStatisticList)
            {
                footballStatistic.FirstDownCons += f.FirstDownCons;
                footballStatistic.Penalties += f.Penalties;
                footballStatistic.Plays += f.Plays;
                footballStatistic.PossessionTime += f.PossessionTime;
                footballStatistic.Sacks += f.Sacks;
                footballStatistic.Turnovers += f.Turnovers;
                footballStatistic.YardsRec += f.YardsRec;
                footballStatistic.YardsRun += f.YardsRun;
            }
            // return total
            return footballStatistic;
        }

        /// <summary>
        /// Summarizes team statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> GetTeamOverallGolfStatistic(Guid id)
        {
            // create golf statistic to return
            GolfStatistic golfStatistic = new GolfStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<GolfStatistic> golfStatisticList = await _repo.GetGolfStatisticByTeamId(id);
            // add all stats together
            foreach (GolfStatistic g in golfStatisticList)
            {
                golfStatistic.Birdies += g.Birdies;
                golfStatistic.Bogeys += g.Bogeys;
                golfStatistic.DriveAccuracy += g.DriveAccuracy;
                golfStatistic.DriveDistance += g.DriveDistance;
                golfStatistic.Eagles += g.Eagles;
                golfStatistic.GIR += g.GIR;
                golfStatistic.PutsperGIR += g.PutsperGIR;
                golfStatistic.SandSaves += g.SandSaves;
                golfStatistic.ScoreToPar += g.ScoreToPar;
                golfStatistic.Scrambles += g.Scrambles;
            }
            // return total
            return golfStatistic;
        }

        /// <summary>
        /// Summarizes team statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> GetTeamOverallHockeyStatistic(Guid id)
        {
            // create hockey statistic to return
            HockeyStatistic hockeyStatistic = new HockeyStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<HockeyStatistic> hockeyStatisticList = await _repo.GetHockeyStatisticByTeamId(id);
            // add all stats together
            foreach (HockeyStatistic h in hockeyStatisticList)
            {
                hockeyStatistic.Blocks += h.Blocks;
                hockeyStatistic.FaceOffWins += h.FaceOffWins;
                hockeyStatistic.GiveAways += h.GiveAways;
                hockeyStatistic.Goals += h.Goals;
                hockeyStatistic.Hits += h.Hits;
                hockeyStatistic.PenaltyMins += h.PenaltyMins;
                hockeyStatistic.PowerPlayOpps += h.PowerPlayOpps;
                hockeyStatistic.Shots += h.Shots;
                hockeyStatistic.TakeAWays += h.TakeAWays;
            }
            // return total
            return hockeyStatistic;
        }

        /// <summary>
        /// Summarizes team statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> GetTeamOverallSoccerStatistic(Guid id)
        {
            // create soccer statistic to return
            SoccerStatistic soccerStatistic = new SoccerStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<SoccerStatistic> soccerStatisticList = await _repo.GetSoccerStatisticByTeamId(id);
            // add all stats together
            foreach (SoccerStatistic s in soccerStatisticList)
            {
                soccerStatistic.CornerKicks += s.CornerKicks;
                soccerStatistic.Fouls += s.Fouls;
                soccerStatistic.Goals += s.Goals;
                soccerStatistic.OffSides += s.OffSides;
                soccerStatistic.PossessionTime += s.PossessionTime;
                soccerStatistic.RedCards += s.RedCards;
                soccerStatistic.ShotOnGoal += s.ShotOnGoal;
                soccerStatistic.yellowCards += s.yellowCards;
            }
            // return total
            return soccerStatistic;
        }


        /*****************************************************************************************/


        // UpdateStatistic -- might want to implement validation checking in these
        /// <summary>
        /// Takes a basketball statistic, retrieves matching basketball statistic to update 
        /// for a team or an individual.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> UpdateStatistic(BasketballStatistic updatedBasketballStatistic)
        {
            // Get player stat line id
            BasketballStatistic basketballStatistic = await _repo.GetBasketballStatisticsById(updatedBasketballStatistic.StatLineID);

            // Add new stats
            basketballStatistic.Assists = updatedBasketballStatistic.Assists;
            basketballStatistic.FGoals = updatedBasketballStatistic.FGoals;
            basketballStatistic.Fouls = updatedBasketballStatistic.Fouls;
            basketballStatistic.FThrows = updatedBasketballStatistic.FThrows;
            basketballStatistic.Rebounds = updatedBasketballStatistic.Rebounds;
            basketballStatistic.Steals = updatedBasketballStatistic.Steals;
            basketballStatistic.Turnovers = updatedBasketballStatistic.Turnovers;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(basketballStatistic);
        }

        /// <summary>
        /// Takes a baseball statistic, retrieves matching baseball statistic to update 
        /// for a team or an individual.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> UpdateStatistic(BaseballStatistic updatedBaseballStatistic)
        {
            // Get player stat line id
            BaseballStatistic baseballStatistic = await _repo.GetBaseballStatisticsById(updatedBaseballStatistic.StatLineID);

            // Add new stats
            baseballStatistic.BattingAve = updatedBaseballStatistic.BattingAve;
            baseballStatistic.ERA = updatedBaseballStatistic.ERA;
            baseballStatistic.Hits = updatedBaseballStatistic.Hits;
            baseballStatistic.RBI = updatedBaseballStatistic.RBI;
            baseballStatistic.Runs = updatedBaseballStatistic.Runs;
            baseballStatistic.Saves = updatedBaseballStatistic.Saves;
            baseballStatistic.Steals = updatedBaseballStatistic.Steals;
            baseballStatistic.StrikeOuts = updatedBaseballStatistic.StrikeOuts;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(baseballStatistic);
        }

        /// <summary>
        /// Takes a football statistic, retrieves matching football statistic to update 
        /// for a team or an individual.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> UpdateStatistic(FootBallStatistic updatedFootballStatistic)
        {
            // Get player stat line id
            FootBallStatistic footballStatistic = await _repo.GetFootballStatisticsById(updatedFootballStatistic.StatLineID);

            // Add new stats
            footballStatistic.FirstDownCons = updatedFootballStatistic.FirstDownCons;
            footballStatistic.Penalties = updatedFootballStatistic.Penalties;
            footballStatistic.Plays = updatedFootballStatistic.Plays;
            footballStatistic.PossessionTime = updatedFootballStatistic.PossessionTime;
            footballStatistic.Sacks = updatedFootballStatistic.Sacks;
            footballStatistic.Turnovers = updatedFootballStatistic.Turnovers;
            footballStatistic.YardsRec = updatedFootballStatistic.YardsRec;
            footballStatistic.YardsRun = updatedFootballStatistic.YardsRun;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(footballStatistic);
        }

        /// <summary>
        /// Takes a golf statistic, retrieves matching golf statistic to update 
        /// for a team or an individual.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> UpdateStatistic(GolfStatistic updatedGolfStatistic)
        {
            // Get player stat line id
            GolfStatistic golfStatistic = await _repo.GetGolfStatisticsById(updatedGolfStatistic.StatLineID);

            // Add new stats
            golfStatistic.Birdies = updatedGolfStatistic.Birdies;
            golfStatistic.Bogeys = updatedGolfStatistic.Bogeys;
            golfStatistic.DriveAccuracy = updatedGolfStatistic.DriveAccuracy;
            golfStatistic.DriveDistance = updatedGolfStatistic.DriveDistance;
            golfStatistic.Eagles = updatedGolfStatistic.Eagles;
            golfStatistic.GIR = updatedGolfStatistic.GIR;
            golfStatistic.PutsperGIR = updatedGolfStatistic.PutsperGIR;
            golfStatistic.SandSaves = updatedGolfStatistic.SandSaves;
            golfStatistic.ScoreToPar = updatedGolfStatistic.ScoreToPar;
            golfStatistic.Scrambles = updatedGolfStatistic.Scrambles;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(golfStatistic);
        }

        /// <summary>
        /// Takes a hockey statistic, retrieves matching hockey statistic to update 
        /// for a team or an individual.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> UpdateStatistic(HockeyStatistic updatedHockeyStatistic)
        {
            // Get player stat line id
            HockeyStatistic hockeyStatistic = await _repo.GetHockeyStatisticsById(updatedHockeyStatistic.StatLineID);

            // Add new stats
            hockeyStatistic.Blocks = updatedHockeyStatistic.Blocks;
            hockeyStatistic.FaceOffWins = updatedHockeyStatistic.FaceOffWins;
            hockeyStatistic.GiveAways = updatedHockeyStatistic.GiveAways;
            hockeyStatistic.Goals = updatedHockeyStatistic.Goals;
            hockeyStatistic.Hits = updatedHockeyStatistic.Hits;
            hockeyStatistic.PenaltyMins = updatedHockeyStatistic.PenaltyMins;
            hockeyStatistic.PowerPlayOpps = updatedHockeyStatistic.PowerPlayOpps;
            hockeyStatistic.Shots = updatedHockeyStatistic.Shots;
            hockeyStatistic.TakeAWays = updatedHockeyStatistic.TakeAWays;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(hockeyStatistic);
        }

        /// <summary>
        /// Takes a soccer statistic, retrieves matching soccer statistic to update 
        /// for a team or an individual.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> UpdateStatistic(SoccerStatistic updatedSoccerStatistic)
        {
            // Get player stat line id
            SoccerStatistic soccerStatistic = await _repo.GetSoccerStatisticsById(updatedSoccerStatistic.StatLineID);

            // Add new stats
            soccerStatistic.CornerKicks = updatedSoccerStatistic.CornerKicks;
            soccerStatistic.Fouls = updatedSoccerStatistic.Fouls;
            soccerStatistic.Goals = updatedSoccerStatistic.Goals;
            soccerStatistic.OffSides = updatedSoccerStatistic.OffSides;
            soccerStatistic.PossessionTime = updatedSoccerStatistic.PossessionTime;
            soccerStatistic.RedCards = updatedSoccerStatistic.RedCards;
            soccerStatistic.ShotOnGoal = updatedSoccerStatistic.ShotOnGoal;
            soccerStatistic.yellowCards = updatedSoccerStatistic.yellowCards;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(soccerStatistic);
        }


        /*****************************************************************************************/


        // DeleteStatistic
        /// <summary>
        /// Takes a basketball statistic and removes it from the database.
        /// </summary>
        /// <param name="basketballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(BasketballStatistic basketballStatistic)
        {
            await _repo.DeleteStatistic(basketballStatistic);
        }

        /// <summary>
        /// Takes a baseball statistic and removes it from the database.
        /// </summary>
        /// <param name="baseballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(BaseballStatistic baseballStatistic)
        {
            await _repo.DeleteStatistic(baseballStatistic);
        }

        /// <summary>
        /// Takes a football statistic and removes it from the database.
        /// </summary>
        /// <param name="footballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(FootBallStatistic footballStatistic)
        {
            await _repo.DeleteStatistic(footballStatistic);
        }

        /// <summary>
        /// Takes a golf statistic and removes it from the database.
        /// </summary>
        /// <param name="golfStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(GolfStatistic golfStatistic)
        {
            await _repo.DeleteStatistic(golfStatistic);
        }

        /// <summary>
        /// Takes a hockey statistic and removes it from the database.
        /// </summary>
        /// <param name="hockeyStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(HockeyStatistic hockeyStatistic)
        {
            await _repo.DeleteStatistic(hockeyStatistic);
        }

        /// <summary>
        /// Takes a soccer statistic and removes it from the database.
        /// </summary>
        /// <param name="soccerStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(SoccerStatistic soccerStatistic)
        {
            await _repo.DeleteStatistic(soccerStatistic);
        }
    }
}
