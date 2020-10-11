﻿using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.Entities;

namespace MyApp.Repositories
{
    /// <summary>
    /// This class is provided as a proxy Mock of the appointment repository 
    /// for use in your implementation. It will return a set of sample data for
    /// appointments and their related details.
    /// </summary>
    public class MockAppointmentRepository : IAppointmentRepository
    {
        IQueryable<Appointment> IAppointmentRepository.GetAppointments(bool includeDeleted)
        {
            return GenerateSampleAppointments().AsQueryable();
        }

        private List<Appointment> GenerateSampleAppointments(int count = 500)
        {
            List<Appointment> appointments = new List<Appointment>();
            for (int counter = 1; counter <= count; counter++)
            {
                var random = new Random(counter);
                var owner = GenerateSampleOwner(counter);
                appointments.Add(new Appointment
                {
                    AppointmentId = Guid.NewGuid(),
                    AppointmentDateTime = DateTime.Today.AddHours(8 + random.Next(8)).AddMinutes(19 + random.Next(21)).AddDays(random.Next(5)),
                    Pet = owner.Pets[random.Next(owner.Pets.Count)],
                    Owner = owner
                });
            }
            return appointments;
        }

        private Owner GenerateSampleOwner(int id)
        {
            int num = 0;
            string petname = "";
            string Fname = "";
            string Lname = "";
            var random = new Random(id);
            num = random.Next(5);

            if (num == 1)
            {
                Fname = "John";
                Lname = "Doe";
            }
            else if (num == 2)
            {
                Fname = "Max";
                Lname = "Justine";
            }
            else if (num == 3)
            {
                Fname = "Sally";
                Lname = "Hills";
            }
            else if (num == 4)
            {
                Fname = "Will";
                Lname = "Norx";
            }
            else
            {
                Fname = "Lebron";
                Lname = "James";
            }
            var owner = new Owner
            {
                OwnerId = Guid.NewGuid(),
                FirstName = Fname,
                LastName = Lname,
                Notes = new List<Note>(),
                Pets = new List<Pet>(),
                IsOptInForNotifications = true,
                Contacts = new List<Contact>()
            };
            //Writting out the firstname of owner
            
            var animals = new List<Animal>(new[]
            {
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Dog", Size =  AnimalSizes.Medium },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Cat", Size =  AnimalSizes.Medium },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Rat", Size =  AnimalSizes.Small },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Pig", Size =  AnimalSizes.Medium },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Horse", Size =  AnimalSizes.Large },
            });

            //setting notes for owner
            
            for (int count = 2; count < random.Next(4); count++)
            { // may have no notes.
                owner.Notes.Add(new Note { NoteId = Guid.NewGuid(), DateCreated = DateTime.Now, DateModified = DateTime.Now, Summary ="Some Note", Detail = "Some note, yadda, yadda." });
            }

            //setting pets for owners
            petname = "";
            num = 0;
            for (int count = 1; count <= random.Next(3)+1; count++)
            {
                num = random.Next(5);
                if (num == 1)
                {
                    petname = "Jacky";
                }else if(num == 2)
                {
                    petname = "Kristy";
                }else if(num == 3)
                {
                    petname = "Kirby";
                }else if(num == 4)
                {
                    petname = "Rusty";
                }
                else
                {
                    petname = "Bella";
                }
                owner.Pets.Add(new Pet { PetId = Guid.NewGuid(), Name = petname, Age = count, Animal = animals[random.Next(4)], Breed = "Unknown", Owner = owner });
            }
            
            //setting the contacts for owner, one is preferred and other one is not
            owner.Contacts.Add(new Contact { ContactId = Guid.NewGuid(), ContactType = ContactTypes.Mobile, ContactData = "04000000" + id.ToString("00"), IsPreferred = true });
            owner.Contacts.Add(new Contact { ContactId = Guid.NewGuid(), ContactType = ContactTypes.EMail, ContactData = "someone@somewhere.com" });

            return owner;
        }
    }
}
