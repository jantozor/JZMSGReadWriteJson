using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JZMSGReadWriteJson
{
    public static class Code_functions
    {
        public static T ReadJson<T>(string json, bool NameHandlingAll = false)
        {
            T clase;
            if (NameHandlingAll)
            {
                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All };
                clase = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, settings);
            }
            else
            {
                clase = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            return clase;
        }
        public static String WriteJson<T>(T clase, bool NameHandlingAll = false)
        {
            string json = "";
            if (NameHandlingAll)
            {
                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All };
                json = Newtonsoft.Json.JsonConvert.SerializeObject(clase, settings);
            }
            else
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(clase);
            }
            return json;
        }
        public static T Read<T>(string dir, bool NameHandlingAll = false)
        {
            return Read<T>(dir, "", "", NameHandlingAll);
        }
        public static T Read<T>(string dir, string success, string fail, bool NameHandlingAll = false)
        {
            StreamReader r = null;
            try
            {
                r = new StreamReader(dir);
                string json = r.ReadToEnd();
                T clase = ReadJson<T>(json, NameHandlingAll);
                r.Close();
                if (success != "")
                    Show(success, "Success", Buttons.OK, Icons.Information);
                return clase;
            }
            catch (Exception ex)
            {
                if (r != null)
                    r.Close();
                if (fail != "")
                    Show(fail, "Warning", Buttons.OK, Icons.Warning);
                return default(T);
            }
        }
        public static T Read<T>(string success, string fail, bool NameHandlingAll = false)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BIM Exchange|*.BEX|All Files|*.*";
            openFileDialog.ShowDialog();
            string dir = openFileDialog.FileName;
            if (dir != "")
            {
                return Read<T>(dir, success, fail, NameHandlingAll);
            }
            else
            {
                Show("File not selected", "Error", Buttons.OK, Icons.Error);
                return default(T);
            }
        }
        public static bool Save<T>(string dir, T save, bool NameHandlingAll = false)
        {
            return Save<T>(dir, save, "", "", NameHandlingAll);
        }
        public static bool Save<T>(string dir, T save, string success, string fail, bool NameHandlingAll = false)
        {
            try
            {
                string json = WriteJson(save, NameHandlingAll);
                if (dir != "" && json != "")
                {
                    File.WriteAllText(dir, json);
                    if (success != "")
                        Show(success, "Success", Buttons.OK, Icons.Information);
                    return true;
                }
                else
                {
                    if (fail != "")
                        Show(fail, "Warning", Buttons.OK, Icons.Warning);
                    return false;
                }
            }
            catch
            {
                if (fail != "")
                    Show(fail, "Warning", Buttons.OK, Icons.Warning);
                return false;
            }
        }
        public static bool Save<T>(T save, string success, string fail, bool NameHandlingAll = false)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "BIM Exchange|*.BEX";
            saveFile.ShowDialog();
            string dir = saveFile.FileName;
            if (dir != "")
            {
                return Save<T>(dir, save, success, fail, NameHandlingAll);
            }
            else
            {
                Show("File directory not selected", "Error", Buttons.OK, Icons.Error);
                return false;
            }
        }
        public static DialogR Show(string message, string title,
        Buttons buttons, Icons icon)
        {
            // Create a host form that is a TopMost window which will be the
            // parent of the MessageBox.
            Form topmostForm = new Form();
            // We do not want anyone to see this window so position it off the
            // visible screen and make it as small as possible
            topmostForm.Size = new System.Drawing.Size(1, 1);
            topmostForm.StartPosition = FormStartPosition.Manual;
            System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10,
            rect.Right + 10);
            topmostForm.Show();
            // Make this form the active form and make it TopMost
            topmostForm.Focus();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;
            // Finally show the MessageBox with the form just created as its owner
            DialogResult result = MessageBox.Show(topmostForm, message, title,
            (MessageBoxButtons)buttons, (MessageBoxIcon)icon);
            topmostForm.Dispose(); // clean it up all the way
            return (DialogR)result;
        }
        public static DialogR Show(string message, string title,
        Buttons buttons)
        {
            return Show(message, title, buttons, Icons.None);
        }
        public static double RoundDown(double round, double mult)
        {
            if (mult == 0)
                mult = 0.01;
            round = round / mult;
            round = Math.Floor(round);
            round = round * mult;
            return round;
        }
        public static double RoundUp(double round, double mult)
        {
            if (mult == 0)
                mult = 0.01;
            round = round / mult;
            round = Math.Ceiling(round);
            round = round * mult;
            return round;
        }
        public static double Round(double round, double mult)
        {
            if (mult == 0)
                mult = 0.01;
            round = round / mult;
            round = Math.Round(round, MidpointRounding.AwayFromZero);
            round = round * mult;
            return round;
        }
        public static int ParseEndInt(ref string text)
        {
            string stack = "";
            for (var i = text.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(text[i]))
                {
                    break;
                }
                stack = text[i] + stack;
                text = text.Remove(i);
            }
            if (stack.Length == 0)
                return 0;
            else
                return int.Parse(stack);
        }
        public enum DialogR : int
        {
            None = DialogResult.None,
            OK = DialogResult.OK,
            Cancel = DialogResult.Cancel,
            Abort = DialogResult.Abort,
            Retry = DialogResult.Retry,
            Ignore = DialogResult.Ignore,
            Yes = DialogResult.Yes,
            No = DialogResult.No,
        }
        public enum Buttons : int
        {
            OK = MessageBoxButtons.OK,
            OKCancel = MessageBoxButtons.OKCancel,
            AbortRetryIgnore = MessageBoxButtons.AbortRetryIgnore,
            YesNoCancel = MessageBoxButtons.YesNoCancel,
            YesNo = MessageBoxButtons.YesNo,
            RetryCancel = MessageBoxButtons.RetryCancel,
        }
        public enum Icons : int
        {
            Asterisk = MessageBoxIcon.Asterisk,
            Error = MessageBoxIcon.Error,
            Exclamation = MessageBoxIcon.Exclamation,
            Hand = MessageBoxIcon.Hand,
            Information = MessageBoxIcon.Information,
            None = MessageBoxIcon.None,
            Question = MessageBoxIcon.Question,
            Stop = MessageBoxIcon.Stop,
            Warning = MessageBoxIcon.Warning,
        }
        public static void CheckNullNames(string name, ValidationResponse added, bool showmsg = true)
        {
            if (name == "" || name == null)
            {
                added.Information = "The name can not be null.";
            }
            else
            {
                added.Information = RemoveForbiddenCharacter(name, false);
            }
            if (showmsg && added.Information != "")
            {
                Show(added.Information, "Warning", Buttons.OK);
            }
        }
        public static string RemoveForbiddenCharacter(string value, bool showmsg = true)
        {
            string result = "";
            bool warn = false;
            if (value == null)
                value = "";

            foreach (char c in value)
            {
                switch (c)
                {
                    case '_':
                    case '\\':
                        warn = true;
                        break;
                    default:
                        result += c;
                        break;
                }
            }
            string msgwarn = "";
            if (warn)
                msgwarn = "The name can not contain (\"_\", \"\\\").";

            if (showmsg)
            {
                if (msgwarn != "")
                    Show(msgwarn, "Warning", Buttons.OK);
            }
            else
            {
                result = msgwarn;
            }
            return result;
        }
    }
    public static class CheckboxDialog
    {
        public static bool ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 180;
            prompt.Height = 100;
            prompt.Text = caption;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            CheckBox chk = new CheckBox();
            chk.Text = text;
            Button ok = new Button() { Text = "Yes" };
            ok.Click += (sender, e) => { prompt.Close(); };
            Button no = new Button() { Text = "No" };
            no.Click += (sender, e) => { prompt.Close(); };
            panel.Controls.Add(chk);
            panel.SetFlowBreak(chk, true);
            panel.Controls.Add(ok);
            panel.Controls.Add(no);
            prompt.Controls.Add(panel);
            prompt.ShowDialog();
            return chk.Checked;
        }
    }
    public class ValidationResponse
    {
        public bool Successful { get; set; }
        public string Information { get; set; }
        public ValidationResponse() { }
        public ValidationResponse(bool succesful)
        {
            Successful = succesful;
            Information = "";
        }
        public ValidationResponse(bool succesful, string information)
        {
            Successful = succesful;
            Information = information;
        }
        public static implicit operator bool(ValidationResponse validationResponse) { return validationResponse.Successful; }
        public static implicit operator ValidationResponse(bool succesful) { return new ValidationResponse(succesful); }
    }
    public class NameEnumConverter : EnumConverter
    {
        private Type _enumType;

        /// Initializing instance
        /// type Enum
        ///this is only one function, that you must
        ///to change. All another functions for enums
        ///you can use by Ctrl+C/Ctrl+V

        public NameEnumConverter(Type type) : base(type)
        {
            _enumType = type;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            System.Reflection.FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            foreach (System.Reflection.FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }
    public class StringValue : System.Attribute
    {
        private readonly string _value;
        public StringValue(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }
    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            try
            {
                Type type = value.GetType();

                //Check first in our cached results...
                //Look for our 'StringValueAttribute'
                //in the field's custom attributes

                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                StringValue[] attrs =
                fi.GetCustomAttributes(typeof(StringValue),
                false) as StringValue[];
                if (attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
            }
            catch
            {
                output = "";
            }
            return output;
        }
        public static string GetDescriptionValue(Enum value)
        {
            string output = null;
            try
            {
                Type type = value.GetType();
                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
                output = dna.Description;
            }
            catch
            {
                output = "";
            }
            return output;
        }
    }
}