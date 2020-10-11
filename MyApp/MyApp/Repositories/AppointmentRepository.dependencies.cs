using System;
using Mehdime.Entity;

namespace MyApp.Repositories
{
    /// <summary>
    /// Dependencies for the appointment repository.
    /// </summary>
    partial class AppointmentRepository
    {
        private IAmbientDbContextLocator ContextScopeLocator { get; set; }
        private NetVetDbContext NetVetDbContext
        {
            get { return ContextScopeLocator.Get<NetVetDbContext>(); }
        }

        public AppointmentRepository(IAmbientDbContextLocator contextScopeLocator)
        {
            ContextScopeLocator = contextScopeLocator ?? throw new ArgumentNullException("contextScopeLocator");
        }
    }
}
