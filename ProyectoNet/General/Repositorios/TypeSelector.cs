using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class TypeSelector
    {
        public static int STRING = 1;
        public static int INTEGER = 2;
        public static int ANYTHING = 3;
        public static int DATE = 4;
        public static int FLOAT = 5;
        public static int LONG = 6;
        public static int BOOLEAN = 7;
        public static int NULL = 9;

        public bool CouldBeInteger(string input)
        {
            try
            {
                int.Parse(input.Replace(",", ""));
                return true;
            }
            catch (FormatException)
            {
                if (input.Trim().Equals(String.Empty))
                    return true;
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
        }

        public bool CouldBeFloat(string input)
        {
            try
            {
                float.Parse(input.Replace(",",""));
                return true;
            }
            catch (FormatException)
            {
                if (input.Trim().Equals(string.Empty)) 
                    return true;
                return false;
            }
        }

        public bool CouldBeLong(string input)
        {
            try
            {
                long.Parse(input.Replace(",",""));
                return true;
            }
            catch (FormatException)
            {
                if (input.Trim().Equals(string.Empty))
                    return true;
                return false;
            }
        }

        public bool CouldBeDate(string input)
        {
            try
            {
                if (!input.Contains(':') || !input.Contains('-') || !input.Contains(' '))
                    if (input.Trim().Equals(string.Empty))
                        return true;
                    else
                        return false;
                DateTime.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                if (input.Trim().Equals(String.Empty))
                    return true;
                return false;
            }
           
        }

        private bool CouldBeBoolean(string input)
        {
            return input.ToLower() == "true" || input.ToLower() == "false";
        }


        public int TypeOf(object input_obj)
        {
            if (input_obj == null) return NULL;
            var input = input_obj.ToString();

            if (input.Trim().Equals(String.Empty))
                return TypeSelector.ANYTHING;
            if (CouldBeDate(input))
                return TypeSelector.DATE;
            if (CouldBeInteger(input))
                return TypeSelector.INTEGER;
            if (CouldBeLong(input))
                return LONG;
            if (CouldBeFloat(input))
                return TypeSelector.FLOAT;
            if (CouldBeBoolean(input))
                return TypeSelector.BOOLEAN;
            return TypeSelector.STRING;
        }



        public int GetType(object input_obj, int previous_type)
        {
            if (input_obj == null) return previous_type;
            
            string input = input_obj.ToString();

            int input_type = TypeOf(input);
            if (previous_type.Equals(NULL)) return input_type;
            
            if (input_type.Equals(STRING) || previous_type.Equals(STRING)) return STRING;
            if (input_type.Equals(ANYTHING)) return previous_type;
            if (previous_type.Equals(ANYTHING)) return input_type;
            if (previous_type.Equals(BOOLEAN))
            {
                if (input_type.Equals(BOOLEAN)) return BOOLEAN;
            }
            if (previous_type.Equals(DATE))
            {
                if (input_type.Equals(INTEGER) || input_type.Equals(FLOAT) || input_type.Equals(LONG)) return STRING;
            }
            if (previous_type.Equals(INTEGER))
            {
                if (input_type.Equals(DATE)) return STRING;
            }
            if (previous_type.Equals(FLOAT))
            {
                if (input_type.Equals(DATE)) return STRING;
                if (input_type.Equals(INTEGER)) return FLOAT;
                if (input_type.Equals(LONG)) return FLOAT;
            }
            if (previous_type.Equals(LONG))
            {
                if (input_type.Equals(INTEGER)) return LONG;
                if (input_type.Equals(DATE)) return STRING;
            }
            return input_type;
        }

        public string TypeName(int type)
        {
            switch (type)
            {
                case 1: return "String";
                case 2: return "Integer";
                case 3: return "Anything";
                case 4: return "Date";
                case 5: return "Float";
                case 6: return "Long";
                case 7: return "Boolean";
                case 8: return "Null";
                default: return "UNKNOWN";

            }
        }

        public Type Type(int type)
        {
            switch (type)
            {
                case 1: return typeof(String);
                case 2: return typeof(int);
                case 3: throw new Exception("Podria ser cualquier tipo");
                case 4: return typeof(DateTime);
                case 5: return typeof(float);
                case 6: return typeof(long);
                case 7: return typeof(Boolean);
                default: throw new Exception("Tipo desconocido");
            }
        }
    }
}
