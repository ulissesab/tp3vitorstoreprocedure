using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp3.Models;

namespace tp3.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Index()
        {
            var friends = new List<FriendModel>();

            SqlDataAdapter adapter = new SqlDataAdapter();
            var connectionString = @"Server = tcp:bdazureteste.database.windows.net,1433; Initial Catalog = infnet; Persist Security Info = False; User ID = ulissesbarbosa; Password ={ Fla1020304050}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
            using (var connection = new SqlConnection(connectionString))
            {

                var procedureName = "ReadFriends";
                    var sqlCommand = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    connection.Open();
                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        while (reader.Read())
                        {
                            var friend = new FriendModel
                            {

                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["FirstName"].ToString(),
                                Email = reader["Email"].ToString(),
                                BirthDate = (DateTime)reader["BirthDate"]


                            };

                            friends.Add(friend);
                        }

                    }

                }
                finally
                {
                    connection.Close();
                }

            }

            return View(friends);
        }

        // GET: Friend/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
