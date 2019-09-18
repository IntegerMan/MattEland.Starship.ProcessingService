using System.Collections.Generic;
using System.Linq;

namespace MattEland.Starship.Logic.Models
{
    public class CrewMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Rank Rank { get; set; }
        public Department Department { get; set; }
        public int DaysInRank { get; set; }
        public IEnumerable<CrewSkill> Skills { get; set; }

        public bool IsEnlisted => this.Rank < Rank.EnsignJg;

        public bool IsOfficer => !this.IsEnlisted;
        public int Id { get; set; }

        public CrewSkill GetSkill(Skill desired)
        {
            //return this.Skills.FirstOrDefault(s => s.Skill == desired);
            return null;
        }

        /*
        private static buildSkills(rank: Rank, department: Department): CrewSkill[] {
            const skills: CrewSkill[] = [];

            const keys = Object.keys(Skill);

            let crewSkill: CrewSkill;
            for (const skill of keys) {
                if (typeof(Skill[skill]) !== 'number') continue;

                crewSkill = new CrewSkill();
                crewSkill.level = 0;
                crewSkill.priority = 0;
                crewSkill.skill = Skill[skill];

                skills.push(crewSkill);
            }

            return skills;
        }
        */

    }
}