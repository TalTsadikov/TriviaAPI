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
    public class InsertPlayerController : ApiController
    {
        public int Get(string name, float score, int correctAnswers, float totalTime)
        {
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
                string sql = $"INSERT INTO triviagame.players (PlayerName, Score, CorrectAnswers, TotalTime) Values (\"{name}\", \"{score}\", \"{correctAnswers}\", \"{totalTime}\");";

                cmd = new MySqlCommand(sql, con);
                rdr = cmd.ExecuteReader();

                return rdr.RecordsAffected;
            }

            return 0;
        }
            // POST: api/InsertPlayer
            public void Post([FromBody]string value)
        {
        }

        // PUT: api/InsertPlayer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/InsertPlayer/5
        public void Delete(int id)
        {
        }
    }
}
