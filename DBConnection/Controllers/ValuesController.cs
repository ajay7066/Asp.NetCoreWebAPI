using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DBConnection.Model;


namespace DBConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration Configuration;
        
        public ValuesController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        private string GetConnectionString()
        {
            return this.Configuration.GetConnectionString("GetConnect");
        }

        [HttpGet]
        public List<MdlCustomer> GetCustomers()
        {
            List<MdlCustomer> Customer = new List<MdlCustomer>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT CustId,CustName FROM Customers";
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Customer.Add(new MdlCustomer()
                        {
                            CustId = Convert.ToInt32(rdr["CustId"]),
                            CustName = rdr["CustName"].ToString()
                        });
                    }
                }
            }
            return Customer;
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            string customer = "";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand()) { 
                    cmd.
                }
            }
            return customer;
        }
        


        
    }
}
