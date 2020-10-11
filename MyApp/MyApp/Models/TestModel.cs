using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MyApp.Repositories;
using MyApp.Entities;

namespace MyApp
{
    public class TestModel
    {
        
        public static List<Appointment> GetAppointments(string name, string date)
        {
            List<Appointment> result = new List<Appointment>();
            IAppointmentRepository repository = new MockAppointmentRepository();

            //Sort the appointments list first according to date and time
            var res = repository.GetAppointments().ToList();
            var test = res.OrderBy(x => x.AppointmentDateTime).ToList();

            //appointment date/time, pet name, owner’s name, and preferred contact details
            //now we parse it and do something with it
            string cmp = "";

            //when both input is present
            if(name!= null && date != null) { 
                //search for name and date
                for (int i = 0; i < test.Count; i++)
                {
                    //take the Date out
                    cmp = test[i].AppointmentDateTime.ToString().Substring(0, 10);
                    if (test[i].Pet.Name == name && cmp == date)
                    {
                        for (int j = 0; j < test[i].Owner.Contacts.Count; j++)
                        {
                            if (test[i].Owner.Contacts[j].IsPreferred == true)
                            {
                                //Puts the contact data into preferred contact
                                test[i].Owner.PreferredContact = test[i].Owner.Contacts[j].ContactData;
                                //Create a new object into results list
                                result.Add(new Appointment
                                {
                                    AppointmentDateTime = test[i].AppointmentDateTime,
                                    Pet = test[i].Pet,
                                    Owner = test[i].Owner
                                });
                            }
                        }
                    }
                }

            }
            //when name is empty
            else if (name == null && date!=null)
            {
                //search for date
                for (int i = 0; i < test.Count; i++)
                {
                    //extract just the date out, *comparison only works if user inputs exactly in mm/dd/yyy format
                    cmp = test[i].AppointmentDateTime.ToString().Substring(0, 10);
                    if (cmp == date)
                    {
                        for (int j = 0; j < test[i].Owner.Contacts.Count; j++)
                        {
                            if (test[i].Owner.Contacts[j].IsPreferred == true)
                            {
                                //Puts the contact data into preferred contact
                                test[i].Owner.PreferredContact = test[i].Owner.Contacts[j].ContactData;
                                //Create a new object into results list
                                result.Add(new Appointment
                                {
                                    AppointmentDateTime = test[i].AppointmentDateTime,
                                    Pet = test[i].Pet,
                                    Owner = test[i].Owner
                                });
                            }
                        }
                    }
                }
            }
            //when date is empty
            else if (date == null && name!=null)
            {
                //search for name
                for (int i = 0; i < test.Count; i++)
                {
                    if (test[i].Pet.Name == name)
                    {
                        for (int j = 0; j < test[i].Owner.Contacts.Count; j++)
                        {
                            if (test[i].Owner.Contacts[j].IsPreferred == true)
                            {
                                //Puts the contact data into preferred contact
                                test[i].Owner.PreferredContact = test[i].Owner.Contacts[j].ContactData;
                                //Create a new object into results list
                                result.Add(new Appointment
                                {
                                    AppointmentDateTime = test[i].AppointmentDateTime,
                                    Pet = test[i].Pet,
                                    Owner = test[i].Owner
                                });
                            }
                        }
                    }
                }
            }
            //When both date and name is empty, display all of 25 results
            else if(date==null && name==null)
            {
                for (int i = 0; i < test.Count; i++)
                {
                    for (int j = 0; j < test[i].Owner.Contacts.Count; j++)
                    {
                        if (test[i].Owner.Contacts[j].IsPreferred == true)
                        {
                            //Puts the contact data into preferred contact
                            test[i].Owner.PreferredContact = test[i].Owner.Contacts[j].ContactData;
                            //Create a new object into results list
                            result.Add(new Appointment
                            {
                                AppointmentDateTime = test[i].AppointmentDateTime,
                                Pet = test[i].Pet,
                                Owner = test[i].Owner
                            });
                        }
                    }
                }
            }
            return result;
        }
    }
}
