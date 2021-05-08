/// Esta clase contiene funciones para encriptar/desencriptar
/// El ser estática no es necesario instanciar un objeto para 
/// usar las funciones Encriptar y DesEncriptar

public static class Seguridad
{
    /// Encripta una cadena
    public static string Encriptar(this string _cadenaAencriptar)
    {
        string result = string.Empty;
        byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
        result = Convert.ToBase64String(encryted);
        return result;
    }

    /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
    public static string DesEncriptar(this string _cadenaAdesencriptar)
    {
    string result = string.Empty;
    byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
    //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
    result = System.Text.Encoding.Unicode.GetString(decryted);
    return result;
    }
}

public static class main()
{
//En el siguiente código podemos ver cómo usar la clase anterior:
public static void main(string[] args)
{

}
protected void btnInicio_Click(object sender, EventArgs e)
        {     
//encriptamos la cadena inicial       
            //txtcadenaencriptada.Text = Seguridad.Encriptar(txtcadenainicial.Text);
            txtcadenaencriptada.Text = Seguridad.Encriptar("Hola");
//ahora desencriptamos
            txtcadenafinal.Text = Seguridad.DesEncriptar(txtcadenaencriptada.Text);
            txtcadenafinal.Text = Seguridad.DesEncriptar();
//Vereis que despues de estas instrucciones txtcadenainial y txtcadenafinal contienen lo mismo.
}*/
}