using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Models
{
    public class MarkupModel
    {
        public Markup markup { get; set; }

        public MarkupModel(float percent, int pips)
        {
            markup = new Markup(percent, pips);
        }
    }

    public class Markup
    {
        public float percent { get; set; }
        public int pips { get; set; }

        public Markup(float percent, int pips)
        {
            this.percent = percent;
            this.pips = pips;
        }
    }
}
