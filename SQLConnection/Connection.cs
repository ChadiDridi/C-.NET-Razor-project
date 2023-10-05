using Microsoft.EntityFrameworkCore;
using AST1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AST1.Pages.Mission;
using Microsoft.AspNetCore.Mvc;
using AST1.Models.ViewModels;
using System.Data;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq.Expressions;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AST1.SQLConnection
{
    public class Connection : DbContext
    {
        // DbSet properties for each entity


        public DbSet<Employerh> Employees { get; set; }
        public DbSet<Affectation> Affectations { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Order> BonAchats { get; set; }
        public DbSet<Hardware> hardwares { get; set; }
        public DbSet<Provider> providers { get; set; }
        SqlConnection _connection = null;
        SqlCommand _command = null;
        private static IConfiguration Configuration { get; set; }

        // Constructor with DbContextOptions injection

        public Connection(DbContextOptions<Connection> options) : base(options)
        {
        }

        public bool Insert(Employerh model)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[AddEmployer]";
                _command.Parameters.AddWithValue("@IdEmployer", model.IdEmployer);
                _command.Parameters.AddWithValue("@NomEmployer", model.NomEmployer);
                _command.Parameters.AddWithValue("@PrenomEmployer", model.PrenomEmployer);
                _command.Parameters.AddWithValue("@EmailEmployer", model.EmailEmployer);
                _command.Parameters.AddWithValue("@PosteEmployer", model.PosteEmployer);
                _command.Parameters.AddWithValue("@TelephoneEmployer", model.TelephoneEmployer);
                _command.Parameters.AddWithValue("@PasswordEmployer", model.PasswordEmployer);
                _connection.Open();
                int result = _command.ExecuteNonQuery();
                return result > 0;
            }
        }
        public bool AddMission(Mission model)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {

                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "AddMission";
                _command.Parameters.AddWithValue("@IdMission", model.IdMission);
                _command.Parameters.AddWithValue("@DateReturnMission", model.DateReturnMission);
                _command.Parameters.AddWithValue("@DescriptionMission", model.DescriptionMission);
                _command.Parameters.AddWithValue("@EmplacementMission", model.EmplacementMission);
                _command.Parameters.AddWithValue("@MvMission", model.MvMission);
                _command.Parameters.AddWithValue("@InsMission", model.InsMission);
                _command.Parameters.AddWithValue("@IdEmployer", model.IdEmployer);
                _command.Parameters.AddWithValue("@IdHardware", model.IdHardware);
                _connection.Open();
                int result = _command.ExecuteNonQuery();
                return result > 0;
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }
        public List<Employerh> GetAll()
        {
            List<Employerh> employeeList = new List<Employerh>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "GetAllEmployees";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Employerh employee = new Employerh();
                    employee.EmailEmployer = reader["EmailEmployer"].ToString();
                    employee.IdEmployer = (int)reader["IdEmployer"];
                    employee.NomEmployer = reader["NomEmployer"].ToString();
                    employee.PrenomEmployer = reader["PrenomEmployer"].ToString();
                    employee.PasswordEmployer = reader["PasswordEmployer"].ToString();
                    employee.PosteEmployer = reader["PosteEmployer"].ToString();
                    employee.TelephoneEmployer = reader["TelephoneEmployer"].ToString();
                    employee.Services = reader["Services"].ToString();
                    employeeList.Add(employee);
                }
                _connection.Close();
            }
            return employeeList;
        }
        public void DeleteEmployee(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "DeleteEmployee";
                _command.Parameters.AddWithValue("@IdEmployer", id);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employerh>().HasData(
                               new Employerh
                               {
                                   IdEmployer = 1,
                                   NomEmployer = "Moussa",
                                   PrenomEmployer = "Moussa",
                                   EmailEmployer = "m@m",
                                   PasswordEmployer = "m",
                                   TelephoneEmployer = "12345678",
                                   PosteEmployer = "Admin",
                                   Services = "Admin"
                               });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }



        //Generate Get Employer by Email
        public Employerh GetEmployeeByEmail(string email)
        {
            return Employees.FirstOrDefault(e => e.EmailEmployer == email);

        }
        // this function works correctly 
        public List<Mission> GetAllMissions()
        {
            List<Mission> missionList = new List<Mission>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[GetAllMissions]";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Mission mission = new Mission();
                    mission.IdMission = (int)reader["IdMission"];
                    mission.MvMission = reader["MvMission"].ToString();
                    mission.InsMission = reader["InsMission"].ToString();
                    mission.DescriptionMission = reader["DescriptionMission"].ToString();
                    mission.DateReturnMission = reader["DateReturnMission"].ToString();
                    mission.IdEmployer = (int)reader["IdEmployer"];
                    mission.IdHardware = (int)reader["IdHardware"];
                    mission.EmplacementMission = reader["EmplacementMission"].ToString();

                    if (reader["DateReturnMission"] != DBNull.Value)
                    {
                        mission.DateReturnMission = reader["DateReturnMission"].ToString();
                    }

                    missionList.Add(mission);
                }
                _connection.Close();
            }
            return missionList;
        }
        public List<Provider> GetAllProviders()
        {
            List<Provider> providers = new List<Provider>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[GetAllProviders]";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Provider provider = new Provider();
                    provider.IdProvider = (int)reader["IdProvider"];
                    provider.NameProvider = reader["NameProvider"].ToString();
                    provider.AdresseProvider = reader["AdresseProvider"].ToString();
                    provider.MailProvider = reader["MailProvider"].ToString();
                    provider.PhoneProvider = reader["PhoneProvider"].ToString();
                    provider.ActifProvider = reader["ActifProvider"].ToString();
                    provider.Phone2Provider = reader["Phone2Provider"].ToString();
                    provider.RaisonSocialProvider = reader["RaisonSocialProvider"].ToString();
                    provider.PaysProvider = reader["PaysProvider"].ToString();


                    providers.Add(provider);
                }
                _connection.Close();
            }
            return providers;
        }
        public List<Hardware> GetAllHardwares()
        {
            List<Hardware> hardwares = new List<Hardware>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "GetAllHardwares";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Hardware hardware = new Hardware();
                    hardware.IdHardware = (int)reader["IdHardware"];
                    hardware.DateHardware = reader["DateHardware"].ToString();
                    hardware.SnHardware = reader["SnHardware"].ToString();
                    hardware.DatecreateHardware = reader["DatecreateHardware"].ToString();
                    hardware.MarqueHardware = reader["MarqueHardware"].ToString();
                    hardware.TypeHardware = reader["TypeHardware"].ToString();
                    hardware.EtatHardware = reader["EtatHardware"].ToString();
                    hardware.ModelHardware = reader["ModelHardware"].ToString();
                    hardware.AvailableHardware = (int)reader["AvailableHardware"];
                    hardware.GrantieHardware = reader["GrantieHardware"].ToString();
                    //hardware.ConsommableHardware= (int)reader["ConsommableHardware"];
                    hardware.LoginHardware = reader["LoginHardware"].ToString();
                    hardware.IdOrder = (int)reader["IdOrder"];
                    //hardware.DescriptionHardware= reader["DescriptionHardware"].ToString();
                    hardwares.Add(hardware);
                }
                _connection.Close();
            }
            return hardwares;
        }
        public void DeleteMission(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "DeleteMission";
                _command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
        }
        public void DeleteProvider(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "DeleteProvider";
                _command.Parameters.AddWithValue("@IdProvider", id);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
        }
        public void DeleteHardware(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "DeleteHardware";
                _command.Parameters.AddWithValue("@IdHardware", id);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void UpdateEmployee(int id,Models.Employerh employee)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NomEmployer", employee.NomEmployer);
                command.Parameters.AddWithValue("@PrenomEmployer", employee.PrenomEmployer);
                command.Parameters.AddWithValue("@EmailEmployer", employee.EmailEmployer);
                command.Parameters.AddWithValue("@PasswordEmployer", employee.PasswordEmployer);
                command.Parameters.AddWithValue("@PosteEmployer", employee.PosteEmployer);
                command.Parameters.AddWithValue("@TelephoneEmployer", employee.TelephoneEmployer);
                command.Parameters.AddWithValue("@Services", employee.Services);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateProvider(Models.Provider provider)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var command = new SqlCommand("UpdateFournisseur", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdProvider", provider.IdProvider);
                command.Parameters.AddWithValue("@RaisonSocialProvider", provider.RaisonSocialProvider);
                command.Parameters.AddWithValue("@AdresseProvider", provider.AdresseProvider);
                command.Parameters.AddWithValue("@PaysProvider", provider.PaysProvider);
                command.Parameters.AddWithValue("@MailProvider", provider.MailProvider);
                command.Parameters.AddWithValue("@PrincipalProvider", provider.PrincipalProvider);
                command.Parameters.AddWithValue("@ActifProvider", provider.ActifProvider);
                command.Parameters.AddWithValue("@PhoneProvider", provider.PhoneProvider);
                command.Parameters.AddWithValue("@Phone2Provider", provider.Phone2Provider);
                command.ExecuteNonQuery();
            }
        }




        public async Task AddEmployee(Models.Employerh addEmployeeRequest)
        {
            var employer = new Models.Employerh()
            {
                NomEmployer = addEmployeeRequest.NomEmployer,
                PrenomEmployer = addEmployeeRequest.PrenomEmployer,
                EmailEmployer = addEmployeeRequest.EmailEmployer,
                PosteEmployer = addEmployeeRequest.PosteEmployer,
                TelephoneEmployer = addEmployeeRequest.TelephoneEmployer,
                Services = addEmployeeRequest.Services,
                PasswordEmployer = addEmployeeRequest.PasswordEmployer
            };

            Employees.Add(employer);
            await SaveChangesAsync();

        }
        public async Task AddProvider(Models.Provider addProviderRequest)
        {
            var provider = new Models.Provider()
            {
                NameProvider = addProviderRequest.NameProvider,
                RaisonSocialProvider = addProviderRequest.RaisonSocialProvider,
                AdresseProvider = addProviderRequest.AdresseProvider,
                PaysProvider = addProviderRequest.PaysProvider,
                MailProvider = addProviderRequest.MailProvider,
                PrincipalProvider = addProviderRequest.PrincipalProvider,
                ActifProvider = addProviderRequest.ActifProvider,
                PhoneProvider = addProviderRequest.PhoneProvider,
                Phone2Provider = addProviderRequest.Phone2Provider
            };

            providers.Add(addProviderRequest);
            await SaveChangesAsync();

        }
        public async Task AddHardware(Models.Hardware addHardware)
        {
            var hardware = new Models.Hardware()
            {
                SnHardware = addHardware.SnHardware,
                DateHardware = addHardware.DateHardware,
                DatecreateHardware = addHardware.DatecreateHardware,
                MarqueHardware = addHardware.MarqueHardware,
                TypeHardware = addHardware.TypeHardware,
                EtatHardware = addHardware.EtatHardware,
                ModelHardware = addHardware.ModelHardware,
                AvailableHardware = addHardware.AvailableHardware,
                GrantieHardware = addHardware.GrantieHardware,
                ConsommableHardware = addHardware.ConsommableHardware,
                LoginHardware = addHardware.LoginHardware,
                IdOrder = addHardware.IdOrder,
                DescriptionHardware = addHardware.DescriptionHardware
            };
            hardwares.Add(hardware);
            await SaveChangesAsync();

        }
        //get employer by ID 
        public Employerh GetEmployeeById(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _connection.Open();
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "GetEmployeeById";
                _command.Parameters.AddWithValue("@IdEmployer", id);

                SqlDataReader reader = _command.ExecuteReader();

                // Check if there are rows in the result set
                if (reader.HasRows)
                {
                    // Read the first row
                    reader.Read();

                    Employerh employer = new Employerh();
                    employer.IdEmployer = (int)reader["IdEmployer"];
                    employer.NomEmployer = reader["NomEmployer"].ToString();
                    employer.PrenomEmployer = reader["PrenomEmployer"].ToString();
                    employer.EmailEmployer = reader["EmailEmployer"].ToString();
                    employer.PasswordEmployer = reader["PasswordEmployer"].ToString();
                    employer.PosteEmployer = reader["PosteEmployer"].ToString();
                    employer.TelephoneEmployer = reader["TelephoneEmployer"].ToString();
                    employer.Services = reader["Services"].ToString();

                    _connection.Close(); // Close the connection

                    return employer; // Return the mapped employer object
                }
            }

            return null; // Return null if no employer is found with the given id
        }
        public Provider GetProviderById(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _connection.Open();
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "GetProviderById";
                _command.Parameters.AddWithValue("@IdProvider", id);
            
            SqlDataReader reader = _command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Provider provider = new Provider();
                provider.IdProvider = (int)reader["IdProvider"];
                provider.NameProvider = reader["NameProvider"].ToString();
                provider.RaisonSocialProvider = reader["RaisonSocialProvider"].ToString();
                provider.AdresseProvider = reader["AdresseProvider"].ToString();
                provider.PaysProvider = reader["PaysProvider"].ToString();
                provider.MailProvider = reader["MailProvider"].ToString();
                provider.PrincipalProvider = reader["PrincipalProvider"].ToString();
                //provider.ActifProvider = (int)reader["ActifProvider"];
                provider.PhoneProvider = reader["PhoneProvider"].ToString();
                provider.Phone2Provider = reader["Phone2Provider"].ToString();

                _connection.Close();
                return provider;
            }
        }
        return null;
        }

      //  public List<Provider> GetAllProviders()
       // {
         //   List<Provider> 
       // }
    

        public List<Models.Order> GetAllOrders()
        {
            List<Order> Orders = new List<Order>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "GetAllOrders";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order();
                    order.IdOrder= (int)reader["IdOrder"];
                    order.InsOrder= reader["InsOrder"].ToString();
                    order.QtsOrder= (int)reader["QtsOrder"];
                    order.DesignationOrder= reader["DesignationOrder"].ToString();
                    order.ReferenceOrder= reader["ReferenceOrder"].ToString();
                    
                    order.QuantiteOrder= (int)reader["QuantiteOrder"];
                   order.SnOrder= reader["SnOrder"].ToString();
                    order.IdProvider= (int)reader["IdProvider"];
                    Orders.Add(order);
                }
                _connection.Close();
            }
            return Orders;
        }
        public void DeleteOrder(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "DeleteOrder";
                _command.Parameters.AddWithValue("@IdOrder", id);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }
        }
        public List<Models.Hardware> GetAllDisponibles()
        {
            List<Hardware> disponibles = new List<Hardware>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "GetAllDisponibles";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Hardware disponible = new Hardware();
                    disponible.IdHardware = (int)reader["IdHardware"];
                    disponible.SnHardware = reader["SnHardware"].ToString();
                    disponible.DatecreateHardware = reader["DatecreateHardware"].ToString();
                    disponible.MarqueHardware = reader["MarqueHardware"].ToString();
                    disponible.TypeHardware = reader["TypeHardware"].ToString();
                    disponible.EtatHardware = reader["EtatHardware"].ToString();
                    disponible.ModelHardware = reader["ModelHardware"].ToString();
                    disponible.AvailableHardware = (int)reader["AvailableHardware"];
                    disponible.GrantieHardware = reader["GrantieHardware"].ToString();
                    //disponible.ConsommableHardware = reader["ConsommableHardware"].ToString();
                    disponible.LoginHardware = reader["LoginHardware"].ToString();
                    disponible.IdOrder = (int)reader["IdOrder"];
                    //disponible.DescriptionHardware = reader["DescriptionHardware"].ToString();
                    disponibles.Add(disponible);
                }
                _connection.Close();
            }
            return disponibles;
        }
        public void DeleteDisponible(int id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "DeleteDisponible";
                _command.Parameters.AddWithValue("@IdHardware", id);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();

            }


        }
    }
    
}


























