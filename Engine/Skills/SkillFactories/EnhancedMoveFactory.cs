using System.Collections.Generic;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.EnhancedMoves;

namespace Game.Engine.Skills.SkillFactories
{
    public class EnhancedMoveFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            Skill skill;
            List<Skill> playerSkills = player.ListOfSkills;
            List<Skill> known = CheckContent(playerSkills);        //checks what enhanced skills player has
            int random = Index.RNG(0, 3);
            if (random <= known.Count)
            {
                skill = known[random];
            }
            else
            {
                skill = known[random];
            }
            if (skill == null)
            {
                AggressiveSword u1 = new AggressiveSword();
                AxeAvadaKedavra u2 = new AxeAvadaKedavra();
                MagicSpear u3 = new MagicSpear();

                List<Skill> temp = new List<Skill>();
                if (u1.MinimumLevel <= player.Level) 
                    temp.Add(u1);
                if (u2.MinimumLevel <= player.Level) 
                    temp.Add(u2);
                if (u3.MinimumLevel <= player.Level) 
                    temp.Add(u3);

                return temp[Index.RNG(0, temp.Count)];
            }
            
            else if (skill.decoratedSkill is null)
            {
                if (skill is AggressiveSword)
                {
                    AggressiveSwordDecorator c1 = new AggressiveSwordDecorator(skill);
                    if (c1.MinimumLevel <= player.Level) 
                        return c1;
                }
                else if (skill is AxeAvadaKedavra)
                {
                    AxeAvadaKedavraDeacorator c2 = new AxeAvadaKedavraDeacorator(skill);
                    if (c2.MinimumLevel <= player.Level) 
                        return c2;
                }
                else if (skill is MagicSpear)
                {
                    MagicSpearDecorator c3 = new MagicSpearDecorator(skill);
                    if (c3.MinimumLevel <= player.Level) 
                        return c3;
                }
                return null; 
            }

            return null;
        }
        private List<Skill> CheckContent(List<Skill> skills)
        {
            List<Skill> temp = new List<Skill>();
            foreach (Skill skill in skills)
            {
                if (skill is AggressiveSword || skill is AxeAvadaKedavra || skill is MagicSpear) 
                    temp.Add(skill);
            }
            return temp;
        } 
    }
}