using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WolsungHeroCreator.HeroLayer;


namespace WolsungHeroCreator.Utils
{
    public static class WriterPDFCard
    {
        private static readonly string logoImageURL = @"Assets/images/logoWolsung.jpg";
        private static readonly string blankenBurgFontURL = @"Assets/blankenburg/Blankenburg.ttf";
        private static readonly string recordaScriptFontURL = @"Assets/recordaScript/RecordaScript.ttf";



        private static Font GetOwnFont(string urlFont)
        {
            BaseFont bOwnFont = BaseFont.CreateFont(urlFont, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font ownFont = new Font(bOwnFont);

            return ownFont;
        }



        private static void DrawLogo(Document doc)
        {
            if (doc == null)
            {
                throw new ArgumentNullException();
            }
            else if (!doc.IsOpen())
            {
                throw new ArgumentException("The document is not open");
            }

            Image logo = Image.GetInstance(logoImageURL);
            logo.ScalePercent(35f);
            logo.Alignment = Image.ALIGN_RIGHT | Image.ALIGN_TOP | Image.TEXTWRAP;

            doc.Add(logo);
        }


        public static void DrawLayout(Document doc, PdfWriter writer)
        {
            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(0, doc.PageSize.Height - 120);
            cb.LineTo(doc.PageSize.Width, doc.PageSize.Height - 120);
            cb.Stroke();

            cb.MoveTo(doc.PageSize.Width / 2 - 80, doc.PageSize.Height - 120);
            cb.LineTo(doc.PageSize.Width / 2 - 80, 0);
            cb.Stroke();

            cb.MoveTo(0, doc.PageSize.Height - 270);
            cb.LineTo(doc.PageSize.Width / 2 - 80, doc.PageSize.Height - 270);
            cb.Stroke();

            cb.MoveTo(0, doc.PageSize.Height - 420);
            cb.LineTo(doc.PageSize.Width / 2 - 80, doc.PageSize.Height - 420);
            cb.Stroke();
        }

        public static void WriteBasicInformations(Document doc,string heroName, string nation, string archetype, string race, string profession)
        {
            if(doc == null)
            {
                throw new ArgumentNullException();
            }
            else if(!doc.IsOpen())
            {
                throw new ArgumentException("The document is not open");
            }


            Font blankenBurgFont    = GetOwnFont(blankenBurgFontURL);
            Font recordaScriptFont  = GetOwnFont(recordaScriptFontURL);

            blankenBurgFont.Size    = 15;
            recordaScriptFont.Size  = 14;

            DrawLogo(doc);

            Chunk cardChunk = new Chunk("Imie i nazwisko:   ", blankenBurgFont);
            Chunk heroChunk = new Chunk(heroName, recordaScriptFont);
            Phrase phraseHeroCard = new Phrase();
            phraseHeroCard.Add(cardChunk);
            phraseHeroCard.Add(heroChunk);
            phraseHeroCard.Add(GetBlankFieldChunk());
            doc.Add(new Paragraph(phraseHeroCard));

            cardChunk = new Chunk("Narodowosc:  ", blankenBurgFont);
            heroChunk = new Chunk(nation, recordaScriptFont);
            phraseHeroCard = new Phrase();
            phraseHeroCard.Add(cardChunk);
            phraseHeroCard.Add(heroChunk);
            phraseHeroCard.Add(GetBlankFieldChunk());
            cardChunk = new Chunk("Archetyp:    ", blankenBurgFont);
            heroChunk = new Chunk(archetype, recordaScriptFont);
            phraseHeroCard.Add(cardChunk);
            phraseHeroCard.Add(heroChunk);
            doc.Add(new Paragraph(phraseHeroCard));

            cardChunk = new Chunk("Rasa:    ", blankenBurgFont);
            heroChunk = new Chunk(race, recordaScriptFont);
            phraseHeroCard = new Phrase();
            phraseHeroCard.Add(cardChunk);
            phraseHeroCard.Add(heroChunk);
            phraseHeroCard.Add(GetBlankFieldChunk());
            cardChunk = new Chunk("Profesja:    ", blankenBurgFont);
            heroChunk = new Chunk(profession, recordaScriptFont);
            phraseHeroCard.Add(cardChunk);
            phraseHeroCard.Add(heroChunk);
            doc.Add(phraseHeroCard);
        }

        public static void WriteAttributesInformation(Document doc, AttributesHandler attributeHandler)
        {
            Font blankenBurgFont = GetOwnFont(blankenBurgFontURL);
            blankenBurgFont.Size = 16;

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Chunk label = new Chunk("***** ATRYBUTY *****", blankenBurgFont);
            doc.Add(new Paragraph(label));

            blankenBurgFont.Size = 13;
            Chunk strElem = new Chunk("Krzepa: " + attributeHandler.Strenght, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Zrecznosc: " + attributeHandler.Agility, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Przenikliwosc: " + attributeHandler.Perception, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Opanowanie: " + attributeHandler.Composure, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Charyzma: " + attributeHandler.Charisma, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            strElem = new Chunk("Kondycja: " + attributeHandler.Endurance, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Reputacja: " + attributeHandler.Reputation, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Obrona: " + attributeHandler.Defence, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Wytrwalosc: " + attributeHandler.Stamina, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

            strElem = new Chunk("Pewnosc siebie: " + attributeHandler.SelfConfidence, blankenBurgFont);
            doc.Add(new Paragraph(strElem));

        }

        public static void WriteSkillsInformation(Document doc, Dictionary<string, Skill> heroSkills)
        {
            Font blankenBurgFont = GetOwnFont(blankenBurgFontURL);
            Font recordaScriptFont = GetOwnFont(recordaScriptFontURL);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            blankenBurgFont.Size = 16;
            Chunk label = new Chunk("***** UMIEJETNOSCI *****", blankenBurgFont);
            doc.Add(new Paragraph(label));

            blankenBurgFont.Size = 13;
            foreach(KeyValuePair<string, Skill> pair in heroSkills)
            {
                Chunk nameSkill = new Chunk(pair.Key+": ", blankenBurgFont);
                Chunk valueSkill = new Chunk(pair.Value.GetLevel().ToString()+"    ", blankenBurgFont);
                Chunk specialSkill = new Chunk(pair.Value.GetSpecialisation(), recordaScriptFont);
                Phrase phrase = new Phrase();
                phrase.Add(nameSkill);
                phrase.Add(valueSkill);
                phrase.Add(specialSkill);
                doc.Add(new Paragraph(phrase));
  
            }
        }

        private static Chunk GetBlankFieldChunk()
        {
            return new Chunk("              ");
        }

    }
}
