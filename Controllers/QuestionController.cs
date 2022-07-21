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
    public class Question
    {
        public string question_text;
        public int id;
        public string ans1_text;
        public string ans2_text;
        public string ans3_text;
        public string ans4_text;
        public int answer_id;
    }

    public class QuestionController : ApiController
    {
        // GET: api/Question
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Question/5
        public Question Get(int id)
        {
            Question q = new Question();
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
                string sql = @"SELECT * FROM triviagame.`questions & answers` where `Q&A ID` =" + id + ";";

                cmd = new MySqlCommand(sql, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    int.TryParse(rdr[0].ToString(), out q.id);
                    q.question_text = rdr[1].ToString();
                    q.ans1_text = rdr[2].ToString();
                    q.ans2_text = rdr[3].ToString();
                    q.ans3_text = rdr[4].ToString();
                    q.ans4_text = rdr[5].ToString();
                    int.TryParse(rdr[6].ToString(), out q.answer_id);
                }
            }

            return q;
        }
        // POST: api/Question
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Question/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Question/5
        public void Delete(int id)
        {
        }
    }
}
