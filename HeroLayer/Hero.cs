using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WolsungHeroCreator.States;
using WolsungHeroCreator.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WolsungHeroCreator.HeroLayer
{
    internal sealed class Hero
    {
        private string race;
        private string nation;
        private string name;
        private string archetype;
        private string profession;

        private AttributesHandler heroAttributes;
        private Dictionary<string, Skill> heroSkills;




        public Hero()
        {
            SetRaceState.GetInstance.ExitState        += new EventHandler(setRaceState_ExitState);
            NationAndNameState.GetInstance.ExitState  += new EventHandler(nationAndNameState_ExitState);
            ArchetypeState.GetInstance.ExitState      += new EventHandler<StringEventArgs>(archetypeState_ExitState);
            ProfessionState.GetInstance.ExitState     += new EventHandler<StringEventArgs>(professionState_ExitState);
            AttributeState.GetInstance.ExitState      += new EventHandler<DictionaryStringIntEventArgs>(attributeState_ExitState);
            SkillsState.GetInstance.ExitState         += new EventHandler<DictionaryStringSkillEventArgs>(skillState_ExitState);
        }






        private void SetRace(string race)
        {
            this.race = race;    
        }

        private void SetNation(string nation)
        {
            this.nation = nation;
        }

        private void SetName(string name)
        {
            this.name = name;
        }

        private void SetArchetype(string archetype)
        {
            this.archetype = archetype;
        }

        private void SetProfession(string profession)
        {
            this.profession = profession;
        }



        private void GetYoursDocuments()
        {
            string fileName = "WOLSUNG - " + name + ".pdf";

            using (Stream output = new FileStream(fileName, FileMode.Create))
            {
                Rectangle docBaseRec = new Rectangle(PageSize.A4);
                docBaseRec.BackgroundColor = BaseColor.GRAY;

                Document heroCard = new Document(docBaseRec);
                PdfWriter writer = PdfWriter.GetInstance(heroCard, output);


                heroCard.Open();

                WriterPDFCard.DrawLayout(heroCard, writer);
                WriterPDFCard.WriteBasicInformations(heroCard, name, nation, archetype, race, profession);
                WriterPDFCard.WriteAttributesInformation(heroCard, heroAttributes);
                WriterPDFCard.WriteSkillsInformation(heroCard, heroSkills);

                heroCard.Close();
            }
        }


        void setRaceState_ExitState(object sender, EventArgs e)
        {
            if(e is StringEventArgs)
            {
                StringEventArgs strEvent = e as StringEventArgs;

                SetRace(strEvent.StringArg);
            }
        }

        void nationAndNameState_ExitState(object sender,EventArgs e)
        {
            if(e is StringEventArgs)
            {
                StringEventArgs strEvent = e as StringEventArgs;

                SetNation(strEvent.StringArg);
                SetName(strEvent.StringArg1);
            }
        }

        void archetypeState_ExitState(object sender, StringEventArgs e)
        {
            SetArchetype(e.StringArg.Substring(0,e.StringArg.Length - 2));
        }

        void professionState_ExitState(object sender, StringEventArgs e)
        {
            SetProfession(e.StringArg);
        }

        void attributeState_ExitState(object sender, DictionaryStringIntEventArgs e)
        {
            heroAttributes = new AttributesHandler();

            heroAttributes.SetAgility(e.args["Agility"]);
            heroAttributes.SetCharisma(e.args["Charisma"]);
            heroAttributes.SetComposure(e.args["Composure"]);
            heroAttributes.SetPerception(e.args["Perception"]);
            heroAttributes.SetStrength(e.args["Strength"]);

            heroAttributes.SetEndurance();
            heroAttributes.SetReputation();
            heroAttributes.SetDefenceAndStamina();
            heroAttributes.SetSelfConfidence();
        }

        void skillState_ExitState(object sender, DictionaryStringSkillEventArgs e)
        {
            heroSkills = e.args;

            GetYoursDocuments();
        }
    }
}
