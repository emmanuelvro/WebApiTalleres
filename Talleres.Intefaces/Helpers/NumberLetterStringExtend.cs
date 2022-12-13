using System.Globalization;
using System.Text.RegularExpressions;

namespace System
{
    public static class AmountInLetter
    {
        public static string Centenas(decimal num)
        {
            decimal valor = num / 100;
            int centenas = Convert.ToInt32(Math.Floor(valor));
            int decenas = Convert.ToInt32(num - (centenas * 100));

            switch (centenas)
            {
                case 1:
                    if (decenas > 0)
                        return "CIENTO " + Decenas(decenas);
                    return "CIEN";

                case 2: return "DOSCIENTOS " + Decenas(decenas);
                case 3: return "TRESCIENTOS " + Decenas(decenas);
                case 4: return "CUATROCIENTOS " + Decenas(decenas);
                case 5: return "QUINIENTOS " + Decenas(decenas);
                case 6: return "SEISCIENTOS " + Decenas(decenas);
                case 7: return "SETECIENTOS " + Decenas(decenas);
                case 8: return "OCHOCIENTOS " + Decenas(decenas);
                case 9: return "NOVECIENTOS " + Decenas(decenas);
            }

            return Decenas(decenas);
        }

        public static string Decenas(int num)
        {
            decimal valor = num / 10;
            int decena = Convert.ToInt32(Math.Floor(valor));
            int unidad = num - (decena * 10);

            switch (decena)
            {
                case 1:
                    switch (unidad)
                    {
                        case 0: return "DIEZ";
                        case 1: return "ONCE";
                        case 2: return "DOCE";
                        case 3: return "TRECE";
                        case 4: return "CATORCE";
                        case 5: return "QUINCE";
                        default: return "DIECI" + Unidades(unidad);
                    }
                case 2:
                    switch (unidad)
                    {
                        case 0: return "VEINTE";
                        default: return "VEINTI" + Unidades(unidad);
                    }
                case 3: return DecenasY("TREINTA", unidad);
                case 4: return DecenasY("CUARENTA", unidad);
                case 5: return DecenasY("CINCUENTA", unidad);
                case 6: return DecenasY("SESENTA", unidad);
                case 7: return DecenasY("SETENTA", unidad);
                case 8: return DecenasY("OCHENTA", unidad);
                case 9: return DecenasY("NOVENTA", unidad);
                case 0: return Unidades(unidad);
            }
            return "";
        }

        public static string DecenasY(string strSin, int numUnidades)
        {
            if (numUnidades > 0)
                return strSin + " Y " + Unidades(numUnidades);

            return strSin;
        }

        public static string Miles(decimal num)
        {
            int divisor = 1000;
            decimal valor = num / divisor;
            int cientos = Convert.ToInt32(Math.Floor(valor));
            decimal resto = num - (cientos * divisor);

            string strMiles = Seccion(num, divisor, "UN MIL", "MIL");
            string strCentenas = Centenas(resto);

            if (strMiles == "")
                return strCentenas;

            return strMiles + " " + strCentenas;
        }

        public static string Millones(decimal num)
        {
            int divisor = 1000000;
            decimal valor = num / divisor;
            int cientos = Convert.ToInt32(Math.Floor(valor));
            decimal resto = num - (cientos * divisor);

            string strMillones = Seccion(num, divisor, "UN MILLON DE", "MILLONES DE");
            string strMiles = Miles(resto);

            if (strMillones == "")
                return strMiles;

            return strMillones + " " + strMiles;
        }

        public static string NumeroALetras(this decimal? num)
        {
            if (num == null)
                num = 0;

            return Convert.ToDouble(num.Value).NumeroALetras();
        }

        public static string NumeroALetras(this decimal num)
        {
            return Convert.ToDouble(num).NumeroALetras();
        }

        public static string NumeroALetras(this double num)
        {
            CultureInfo culturaMexico = new CultureInfo("es-MX");
            if (culturaMexico.Name != "es-MX")
            {
                return "Error en la configuración {" + culturaMexico.Name + "}  NO CONTINUES CON LA OPERACIÓN, favor de llamar a tu administrador";
            }
            double numeroMexico = double.Parse(num.ToString(), culturaMexico);

            double numero = numeroMexico;
            int enteros = Convert.ToInt32(Math.Floor(numeroMexico));
            int centavos = Convert.ToInt32((((Math.Round(numeroMexico * 100)) - (Math.Floor(numeroMexico) * 100))));
            string letrasCentavos = "";
            string letrasMonedaPlural = "PESOS";
            string letrasMonedaSingular = "PESO";
            //string letrasMonedaCentavoPlural = "CENTAVOS";
            //string letrasMonedaCentavoSingular = "CENTAVO";

            if (centavos > 0)
            {
                //letrasCentavos = " con  " + (centavos == 1 ? Millones(centavos) + ' ' + letrasMonedaCentavoSingular : Millones(centavos) + ' ' + letrasMonedaCentavoPlural);
                letrasCentavos = " " + centavos.ToString() + "/100 MN.";
            }
            if (centavos == 0)
            {
                letrasCentavos = " 00/100 MN.";
            }

            if (enteros == 0)
            {
                return "CERO " + letrasMonedaPlural + " " + letrasCentavos;
            }

            if (enteros == 1)
            {
                return Millones(enteros) + " " + letrasMonedaSingular + " " + letrasCentavos;
            }
            else
            {
                return Millones(enteros) + " " + letrasMonedaPlural + " " + letrasCentavos;
            }
        }

        public static string Seccion(decimal num, int divisor, string strSingular, string strPlural)
        {
            decimal valor = num / divisor;
            int cientos = Convert.ToInt32(Math.Floor(valor));
            decimal resto = num - (cientos * divisor);

            string letras = "";

            if (cientos > 0)
                if (cientos > 1)
                    letras = Centenas(cientos) + " " + strPlural;
                else
                    letras = strSingular;

            if (resto > 0)
                letras += "";

            return letras;
        }

        public static string Unidades(int num)
        {
            switch (num)
            {
                case 1: return "UN";
                case 2: return "DOS";
                case 3: return "TRES";
                case 4: return "CUATRO";
                case 5: return "CINCO";
                case 6: return "SEIS";
                case 7: return "SIETE";
                case 8: return "OCHO";
                case 9: return "NUEVE";
            }

            return "";
        }
    }

    public static class NumberLetterStringExtend
    {
        private static readonly String[] centenas = {"", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};

        private static readonly String[] decenas = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};

        private static readonly String[] unidades = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
        private static Regex r;

        public static string GetNumberLetter(this string numero, bool mayusculas = true, string moneda = "PESOS")
        {
            if (string.IsNullOrEmpty(numero))
                return numero;

            String literal;
            String parte_decimal;
            //si el numero utiliza (.) en lugar de (,) -> se reemplaza
            numero = numero.Replace(".", ",", StringComparison.InvariantCultureIgnoreCase);

            //si el numero no tiene parte decimal, se le agrega ,00
            if (!numero.Contains(",", StringComparison.CurrentCulture))
            {
                numero = numero + ",00";
            }
            //se valida formato de entrada -> 0,00 y 999 999 999,00
            r = new Regex(@"\d{1,9},\d{1,2}");
            MatchCollection mc = r.Matches(numero);
            if (mc.Count > 0)
            {
                //se divide el numero 0000000,00 -> entero y decimal
                String[] Num = numero.Split(',');

                string MN = " M.N.";
                if (moneda != "PESOS")
                    MN = "";

                //de da formato al numero decimal
                parte_decimal = moneda + " " + Num[1] + "/100" + MN;
                //se convierte el numero a literal
                if (int.Parse(Num[0]) == 0)
                {//si el valor es cero
                    literal = "cero ";
                }
                else if (int.Parse(Num[0]) > 999999)
                {//si es millon
                    literal = getMillones(Num[0]);
                }
                else if (int.Parse(Num[0]) > 999)
                {//si es miles
                    literal = getMiles(Num[0]);
                }
                else if (int.Parse(Num[0]) > 99)
                {//si es centena
                    literal = getCentenas(Num[0]);
                }
                else if (int.Parse(Num[0]) > 9)
                {//si es decena
                    literal = getDecenas(Num[0]);
                }
                else
                {//sino unidades -> 9
                    literal = getUnidades(Num[0]);
                }
                //devuelve el resultado en mayusculas o minusculas
                if (mayusculas)
                {
                    return (literal + parte_decimal).ToUpper();
                }
                else
                {
                    return (literal + parte_decimal);
                }
            }
            else
            {//error, no se puede convertir
                return null;
            }
        }

        /* funciones para convertir los numeros a literales */

        private static string getCentenas(String num)
        {// 999 o 099
            if (int.Parse(num) > 99)
            {//es centena
                if (int.Parse(num) == 100)
                {//caso especial
                    return " cien ";
                }
                else
                {
                    return centenas[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
                }
            }
            else
            {//por Ej. 099
                //se quita el 0 antes de convertir a decenas
                return getDecenas(int.Parse(num) + "");
            }
        }

        private static string getDecenas(String num)
        {// 99
            int n = int.Parse(num);
            if (n < 10)
            {//para casos como -> 01 - 09
                return getUnidades(num);
            }
            else if (n > 19)
            {//para 20...99
                String u = getUnidades(num);
                if (u.Equals(""))
                { //para 20,30,40,50,60,70,80,90
                    return decenas[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    return decenas[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
                }
            }
            else
            {//numeros entre 11 y 19
                return decenas[n - 10];
            }
        }

        private static string getMiles(String numero)
        {// 999 999
            //obtiene las centenas
            String c = numero.Substring(numero.Length - 3);
            //obtiene los miles
            String m = numero.Substring(0, numero.Length - 3);
            String n = "";
            //se comprueba que miles tenga valor entero
            if (int.Parse(m) > 0)
            {
                n = getCentenas(m);
                return n + "mil " + getCentenas(c);
            }
            else
            {
                return "" + getCentenas(c);
            }
        }

        private static string getMillones(String numero)
        { //000 000 000
            //se obtiene los miles
            String miles = numero.Substring(numero.Length - 6);
            //se obtiene los millones
            String millon = numero.Substring(0, numero.Length - 6);
            String n = "";
            if (millon.Length > 1)
            {
                n = getCentenas(millon) + "millones ";
            }
            else
            {
                n = getUnidades(millon) + "millon ";
            }
            return n + getMiles(miles);
        }

        private static string getUnidades(String numero)
        {   // 1 - 9
            //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
            String num = numero.Substring(numero.Length - 1);
            return unidades[int.Parse(num)];
        }
    }
}