using Programming_Assignment_1.Models;
using Programming_Assignment_1.NewFolder;
using System.Collections.Generic;

namespace Programming_Assignment_1
{
    public class Program
    {

        //public static List<Client> CList = new List<Client>();
        //public static List<Project> PList = new List<Project>();

        static ProjectService ProjectList = ProjectService.Current;
        static ClientService ClientList = ClientService.Current;

        public static void Main(string[] args)
        {
            bool run = true;
            do
            {
                Console.WriteLine("--------Client and Project Menu--------");
                Console.WriteLine("P. Project Menu");
                Console.WriteLine("C. Client Menu");
                Console.WriteLine("E. Exit");
                var x = Console.ReadLine() ?? string.Empty;

                if (x.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    PMenu();

                }
                else if (x.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    CMenu();
                }else if(x.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                {
                    run = false;
                }
                else
                {
                    Console.Write("Invalid Input, please try again.");
                }

            } while (run);
            
        
        }


        static void PMenu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("---------MENU--------");
                Console.WriteLine("C-\tAdd Project to List");
                Console.WriteLine("R-\tRead Project List");
                Console.WriteLine("U-\tUpdate Project List");
                Console.WriteLine("D-\tDelete from List");
                Console.WriteLine("E-\tExit");


                var x = Console.ReadLine() ?? string.Empty;


                if (x.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter Id: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Enter Client Id: ");
                    ClientList.Read();

                    var Cid = int.Parse(Console.ReadLine() ?? "0");

                    if(ProjectList.Get(id) != null) 
                    {
                        Console.WriteLine("Project already exits.");
                    }
                    else if(ClientList.Get(Cid) == null)
                    {
                        Console.WriteLine("Client Id not found/No Clients in List");
                    }
                    else
                    {
                        ProjectList.Add(new Project()
                        {
                            Id = id
                        ,
                            ClientId = Cid
                        ,
                            OpenDate = DateTime.Now
                        ,
                            ShortName = ClientList.Get(Cid).Name
                        }
                    );
                        Console.WriteLine("Project Successfully Added");

                    }

                }
                else
                if (x.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Project ID Client ID ShortName\tStatus");
                    ProjectList.Read();
                }
                else if (x.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter Project Id to Update: ");
                    ProjectList.Read();
                    var UpdateId = int.Parse(Console.ReadLine() ?? "0");
                    var ProjecttoUpdate = ProjectList.Get(UpdateId);
                    if (ProjecttoUpdate != null)
                    {
                        UpdateProj(ProjecttoUpdate);
                    }
                    else
                    {
                        Console.WriteLine("Project Id does not exist.");
                    }


                }
                else if (x.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter Client Id to Be Removed: ");
                    ProjectList.Read();
                    var del = int.Parse(Console.ReadLine() ?? "0");

                    var ProjecttoRemove = ProjectList.Get(del);

                    if (ProjecttoRemove != null)
                        ProjectList.Remove(ProjecttoRemove);

                }else if(x.Equals("E",StringComparison.InvariantCultureIgnoreCase)) 
                { 
                    run = false; 
                }
            }
        }


      
        static void CMenu()
        {
            bool run = true;

            while (run)
            {
                    Console.WriteLine("---------MENU--------");
                    Console.WriteLine("C-\tAdd Client to List");
                    Console.WriteLine("R-\tRead Client List");
                    Console.WriteLine("U-\tUpdate Client List");
                    Console.WriteLine("D-\tDelete from List");
                    
                    if (ClientList.Count() > 0)
                    {
                        Console.WriteLine("P-\tCreate a Project");
                    }
                    
                    Console.WriteLine("E-\tExit");
                      
                    

                    var x = Console.ReadLine() ?? string.Empty;


                if (x.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter Name: ");
                    var name = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter ID: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");

                    if(ClientList.Get(id) != null)
                    {
                        Console.WriteLine("Client ID already exists");
                    }
                    else
                    {

                        if(name.Equals(string.Empty))
                        {
                            name = "Jane/John Doe";
                        }

                        ClientList.Add(new Client
                        {
                            Name = name
                        ,
                            Id = id
                        ,
                            OpenDate = DateTime.Now
                        }
                    );

                        Console.WriteLine("Client Successfully Added");
                    }



                } else
                if (x.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("ID\tName\tStatus");
                    ClientList.Read();
                } else if (x.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter Client Id to Update: ");
                    ClientList.Read();
                    var UpdateId = int.Parse(Console.ReadLine() ?? "0");
                    var ClienttoUpdate = ClientList.Get(UpdateId);
                    if(ClienttoUpdate != null)
                    {
                        UpdateL(ClienttoUpdate);
                    }


                } else if (x.Equals("D", StringComparison.InvariantCultureIgnoreCase)) {
                    Console.WriteLine("Enter Client Id to Be Removed: ");
                    ClientList.Read();
                    var del = int.Parse(Console.ReadLine() ?? "0");

                    var ClienttoRemove = ClientList.Get(del);

                    if (ClienttoRemove != null)
                        ClientList.Remove(ClienttoRemove);

                } else if (x.Equals("E", StringComparison.InvariantCultureIgnoreCase)) {
                    run = false;
                }
                else if (x.Equals("P", StringComparison.InvariantCultureIgnoreCase) && ClientList.Count() > 0)
                {
                    Console.WriteLine("Enter Id: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Enter Client Id: ");
                    ClientList.Read();

                    var Cid = int.Parse(Console.ReadLine() ?? "0");

                    if (ProjectList.Get(id) != null)
                    {
                        Console.WriteLine("Project already exits.");
                    }
                    else if (ClientList.Get(Cid) == null)
                    {
                        Console.WriteLine("Client Id not found");
                    }
                    else
                    {
                        ProjectList.Add(new Project()
                        {
                            Id = id
                        ,
                            ClientId = Cid
                        ,
                            OpenDate = DateTime.Now
                        ,
                            ShortName = ClientList.Get(Cid).Name
                        ,
                            IsActive = false
                        }
                    ) ;
                    }
                }


            }

        }

        static void UpdateProj(Project proj)
            {
                Console.WriteLine("Select Attribute to update: ");
                Console.WriteLine("N. Name");
                Console.WriteLine("E. Change/Link Client Id");
                Console.WriteLine("A. Activate");
                Console.WriteLine("D. Deactivate");
                Console.WriteLine("C. Set Open/Close Project");
                Console.WriteLine("Q. Cancel");

            var choice = Console.ReadLine() ?? string.Empty;

            if (choice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("S. Short name");
                Console.WriteLine("L. Long name");
                
                var c = Console.ReadLine() ?? string.Empty;

                ChangeP(proj, c);
            }else if(choice.Equals("E", StringComparison.InvariantCultureIgnoreCase)) //--------------------------------------------------
            {
                Console.WriteLine("Enter Client Id to Link: ");
                ClientList.Read();
                var ID = int.Parse(Console.ReadLine() ?? "0");

                var c = ClientList.Get(ID);
                if(c != null)
                {
                    proj.ClientId = ID;
                }
                else
                {
                    Console.WriteLine("Client Id does not Exist");
                }

                
            }else if(choice.Equals("A", StringComparison.InvariantCultureIgnoreCase)) 
            {
                proj.IsActive = true;

            }
            else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
            {
                proj.IsActive = false;

            }else if(choice.Equals("C", StringComparison.InvariantCultureIgnoreCase)) 
            {
                Console.WriteLine("Update Close date to today? Y/N");
                var x = Console.ReadLine() ?? string.Empty;
                if (x.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    proj.CloseDate = DateTime.Now;
                    proj.IsActive = false;
                }
            }else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
            {
               
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }


        static void ChangeP(Project s, string str)
        {


            var Change = Console.ReadLine() ?? string.Empty;
            if (str.Equals("N",StringComparison.InvariantCultureIgnoreCase))
            {
                s.Name = Change;
                Console.WriteLine("Name Changed");
            }
            else if (str.Equals("E", StringComparison.InvariantCultureIgnoreCase))
            {
                s.Notes = Change;
                Console.WriteLine("Notes Changed");

            }else { Console.WriteLine("Invalid Input"); }
        }

        static void UpdateL(Client s)
        {
            Console.WriteLine("Select Attribute to update: ");
            Console.WriteLine("N. Name");
            Console.WriteLine("E. Notes");
            Console.WriteLine("A. Activate");
            Console.WriteLine("D. Deactivate");
            Console.WriteLine("C. Set Open/Close Client");
            Console.WriteLine("Q. Cancel");

            var choice = Console.ReadLine() ?? string.Empty;

            if (choice.Equals("N", StringComparison.InvariantCultureIgnoreCase) || choice.Equals("E", StringComparison.InvariantCultureIgnoreCase))
            {
                ChangeV(s, "N");
            }
            else if (choice.Equals("A", StringComparison.InvariantCultureIgnoreCase))
            {
                s.IsActive = true;
                Console.WriteLine("Client set to Active");
            }
            else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
            {
                s.IsActive = false;
                Console.WriteLine("Client set to Inactive");

            }else if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Update Close date to today? Y/N");
                var x = Console.ReadLine() ?? string.Empty;
                if (x.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    s.CloseDate = DateTime.Now;
                    s.IsActive = false;
                }
            }
            else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
            {
             
            }

        }


        static void ChangeV(Client s, string str)
        {
            Console.WriteLine("Enter the new attribute: ");

            var Change = Console.ReadLine() ?? string.Empty;
            if (str.Equals("N")) {
                s.Name = Change;
                Console.WriteLine("Name Changed");
            }else if (str.Equals("E"))
            {     
                s.Notes = Change;
                Console.WriteLine("Notes Changed");

            }
        }
    }
}