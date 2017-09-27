using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.IO.Ports;

namespace Arthur
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        bool wake = true;

        SerialPort port = new SerialPort("Com4",9600,Parity.None,8,StopBits.One);

        Choices list = new Choices();

        public Form1()
        {

            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new string[] { "Wake", "Sleep", "Arthur are you listening?", "Hey Arthur", "How Are You doing today?", "Open Google", "Open Facebook", "Open Pogo", "Open Twitter", "Play Music", "Start Netflix", "Who Created You?", "Who is Skyler Stevens?", "What is an apple?", "What time is it?", "Whats up arthur?", "What is today?", "Do you want to smoke a blunt Arthur", "light on", "light off", });



            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {

                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }



            s.SelectVoiceByHints(VoiceGender.Male);
            InitializeComponent();
        }
        public void say(string h)
        {
            s.Speak(h);
        }

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            if
                (r == "Wake") wake = true;
            {
                if
                    (r == "Sleep") wake = false;
            }


            if (wake == true) ;

            {

                if (r== "light on")
                {
                    port.Open();
                    port.WriteLine("A");
                    port.Close();
                }

                if (r== "light off")
                {
                    port.Open();
                    port.WriteLine("B");
                    port.Close();
                }


                if (r == "Arthur are you listening?")
                {
                    say("For you sir, anytime i'm always looking to help you cameron");
                }

                if (r == "How Are You doing today?")
                {
                    say("I'm Great");
                }

                if (r == "Who Created You?")
                {
                    say("I Was Created by Cameron Watson");
                }
                if (r == "Who is Skyler Stevens?")
                {
                    say("Skyler stevens, is Cameron Watson's Best friend!");

                }
                if (r == "What is an apple?")
                {
                    say("The apple, is a famous red fruit.Deciduous tree, generally standing (6 to 15 ft) tall in cultivation and up to 39 ft in the wild.[4]When cultivated, the size, shape and branch density are determined by rootstock selection and trimming method. The leaves are alternately arranged dark green-colored simple ovals with serrated margins and slightly downy undersides");
                }
                if (r == "Open Facebook")
                {
                    Process.Start("http://www.facebook.com");
                }
                if (r == "Open Google")
                {
                    Process.Start("http://www.google.com");
                }
                if (r == "What time is it?")
                {
                    say(DateTime.Now.ToString("h: mm tt"));
                }
                if (r == "What is today?")
                {
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }
                if (r == "Do you want to smoke a blunt Arthur")
                {
                    say("No thank you! I don't smoke i think it would be bad for my internal components");
                }
                if (r == "Whats up arthur?")
                {
                    say("Not shit just chilling in the computer.Can I help you with something?");
                }

            }
        }
    }
}

      
