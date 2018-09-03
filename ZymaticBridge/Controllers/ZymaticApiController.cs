using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using ZymaticBridge.Models;
using System.Collections.Concurrent;

namespace ZymaticBridge.Controllers
{  
    public class ZymaticApiController
    {
        private const string  SYSTEM_USER = "00000000000000000000000000000000";
         
        private static ConcurrentDictionary<string, BrewSession> _Sessions { get; set; }

        static ZymaticApiController()
        {
            _Sessions = new ConcurrentDictionary<string, BrewSession>();
        }

        /// <summary>
        /// Initial handshake for pulling your recipes or cleaning
        /// </summary>
        /// <param name="user"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("API/SyncUser")]
        public string SyncUser(string user,string machine)
        {
         

            Console.WriteLine(string.Format("SynUser {0},{1}", user, machine));

            if(user == SYSTEM_USER)
            { 
                return GetCleaningRecipes();
            }
            else //TODO: support multi tenant brewing. Not a priority now. Use picobrew.com if you want that
            {
                return GetPicoBrewRecipes();
            }
        }


        [HttpGet] 
        [Route("API/logsession")]
        public string LogSession(SessionViewModel model)
        {
            Console.WriteLine("LogSession");
            
            if (string.IsNullOrWhiteSpace(model.session))
            {
                var recipe = RecipeLoader.Recipes.Where(p => p.Hash == model.recipe).FirstOrDefault();

                if(recipe!=null)
                {
                    BrewSession session = new BrewSession(recipe);

                    _Sessions.TryAdd(session.SessionId, session);

                    return session.SessionId;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {

                BrewSession session = null;

                if(_Sessions.ContainsKey(model.session))
                    session = _Sessions[model.session];

                if(session!=null)
                {
                    switch (model.code)
                    {
                        //new step
                        case 1:
                            session.CurrentStep = model.step;

                            Console.WriteLine("LogSession new step " + model.data);

                            break;
                        
                        //data readings
                        case 2:
                            session.DataReadings.Add(model.data);
                            Console.WriteLine("LogSession " + model.data);
                             
                            break;

                        //end session
                        case 3:
                            
                            _Sessions.Remove(model.session,out session);

                            break;
                    }
                }
               

                return string.Empty;
            }
        }


        /// <summary>
        /// Seems to be pointless. Some kind of ping/pointless reason to cause a brew to crash? Maybe keep session state alive
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("API/checkSync")]
        public string CheckSync(string user)
        {
            Console.WriteLine("CheckSync " + user);
            return "\r\n#!#";
        }

        private string GetCleaningRecipes()
        {
            return "#Cleaning v1/7f489e3740f848519558c41a036fe2cb/Heat Water,152,0,0,0/Clean Mash,152,15,1,5/Heat to Temp,152,0,0,0/Adjunct,152,3,2,1/Adjunct,152,2,3,1/Adjunct,152,2,4,1/Adjunct,152,2,5,1/Heat to Temp,207,0,0,0/Clean Mash,207,10,1,0/Clean Mash,207,2,1,0/Clean Adjunct,207,2,2,0/Chill,120,10,0,2/|Rinse v3/0160275741134b148eff90acdd5e462f/Rinse,0,2,0,5/|#";
        }

        /// <summary>
        /// Take your recipes and return as a pipe delimted string
        /// </summary>
        /// <returns></returns>
        private string GetPicoBrewRecipes()
        {
            StringBuilder recipeList = new StringBuilder();

            foreach(var recipe in RecipeLoader.Recipes)
            {
                recipeList.Append(recipe.ToString());
            }

            return recipeList.ToString();
        }
    }
}
