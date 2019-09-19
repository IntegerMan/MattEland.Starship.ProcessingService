using System;
using MattEland.Starship.Logic.Models;
using MattEland.Starship.Logic.Models.Crew;

namespace MattEland.Starship.Logic.Simulation
{
    public class CrewFactory
    {
        public CrewMember Create(Department department, int id)
        {
            CrewMember member;

            switch (department)
            {
                case Department.Science:
                    member = new ScienceSpecialist(id);
                    break;

                case Department.Engineering:
                    member = new MaintenanceTechnician(id);
                    break;

                case Department.Medical:
                    member = new MedicalSpecialist(id);
                    break;

                case Department.Operations:
                    member = new OperationsSpecialist(id);
                    break;

                case Department.Tactical:
                    member = new TacticalSpecialist(id);
                    break;

                case Department.Command:
                    member = new Commander(id);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(department), department, null);
            }

            member.Department = department;

            return member;
        }
    }
}