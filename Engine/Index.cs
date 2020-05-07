using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Interactions;
using Game.Engine.Interactions.InteractionFactories;
using Game.Engine.Items.Weapon;

namespace Game.Engine
{
    // contains information about skills, items and monsters that will be available in the game
    public partial class Index
    {
        private static List<SkillFactory> magicSkillFactories = new List<SkillFactory>()
        {
            new BasicSpellFactory()
        };

        private static List<SkillFactory> weaponSkillFactories = new List<SkillFactory>()
        {
            new BasicWeaponMoveFactory()
        };

        private static List<Item> items = new List<Item>()
        {
            new BasicStaff(),
            new BasicSpear(),
            new BasicAxe(),
            new BasicSword(),
            new SteelArmor(),
            new AntiMagicArmor(),
            new BerserkerArmor(),
            new GrowingStoneArmor(),
            new Wand(),
            new MinthrilArmor(),
            new SuperSword()
        };

        private static List<ItemFactory> itemFactories = new List<ItemFactory>()
        {
            new BasicArmorFactory(),
            new WeaponFactory()
        };

        private static List<MonsterFactory> monsterFactories = new List<MonsterFactory>()
        {
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.WizardFactory(),
            new Monsters.MonsterFactories.TheGrokeFactory()
        };

        private static List<InteractionFactory> interactionFactories = new List<InteractionFactory>()
        {
            new SkillForgetFactory(),
            new GymirHymirFactory()
        };

    }
}
