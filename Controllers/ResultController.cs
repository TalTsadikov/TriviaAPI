using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TriviaAPI.Controllers
{
    public class ResultController : ApiController
    {
        public class PlayerResult
        {
            public int id;
            public string player_name;
            public float score;
            public int correct_ans;
            public float total_time;
        }

        public IEnumerable<PlayerResult> Get()
        {
            List<PlayerResult> playerList = new List<PlayerResult>();
            PlayerResult p = new PlayerResult();
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader rdr;
            string con_string = "server=127.0.0.1;uid=root;database=triviagame;Charset=utf8";
            con = new MySqlConnection();
            con.ConnectionString = con_string;
            con.Open();
            string result = "";
            if (con.State == System.Data.ConnectionState.Open)
            {
                string sql = @"SELECT * FROM triviagame.players Order by Score DESC Limit 5;";

                cmd = new MySqlCommand(sql, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   p = new PlayerResult();
                   int.TryParse(rdr[0].ToString(), out p.id);
                   p.player_name = rdr[1].ToString();
                   float.TryParse(rdr[2].ToString(), out p.score);
                   int.TryParse(rdr[3].ToString(), out p.correct_ans);
                   float.TryParse(rdr[4].ToString(), out p.total_time);
                   playerList.Add(p);
                }
            }

            return playerList;
        }
        // POST: api/Result
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Result/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Result/5
        public void Delete(int id)
        {
        }
    }
}
