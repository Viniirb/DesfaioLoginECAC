using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Seja bem-vindo ao Desafio de Login do ECAC.");
        Console.WriteLine("Estarei utilizando a opção de login via Certificado A1.");

        // Realizando a solicitação do caminho do certificado
        string pathCertificado = ObterCaminhoCertificado();

        // Realizando a solicitação da senha do certificado
        string passwordCertificado = ObterSenhaCertificado();

        // Realizando envio dos dados do certificado para login
        await EnviarCertificado(pathCertificado, passwordCertificado);
    }

    /// <summary>
    /// Método realizado para obter o caminho do certificado corretamente.
    /// </summary>
    /// <returns></returns>
    static string ObterCaminhoCertificado()
    {
        string? certPath;
        do
        {
            Console.WriteLine("Por favor, insira o caminho do arquivo do certificado:");
            certPath = Console.ReadLine();

            if (string.IsNullOrEmpty(certPath) || !System.IO.File.Exists(certPath))
            {
                Console.WriteLine("Caminho do certificado inválido. Tente novamente.");
            }

        } while (string.IsNullOrEmpty(certPath) || !System.IO.File.Exists(certPath));

        return certPath;
    }

    /// <summary>
    /// Método realizado para obter a senha do certificado corretamente.
    /// </summary>
    /// <returns></returns>
    static string ObterSenhaCertificado()
    {
        SecureString securePassword = new SecureString();
        Console.WriteLine("Por favor, insira a senha do certificado:");

        // Aqui esta sendo realizado a leitura da senha de forma segura
        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
                break;

            if (key.Key == ConsoleKey.Backspace && securePassword.Length > 0)
            {
                securePassword.RemoveAt(securePassword.Length - 1);
                Console.Write("\b \b");
            }
            else
            {
                securePassword.AppendChar(key.KeyChar);
                Console.Write("*");
            }
        }

        // Convertendo SecureString para string (apenas para o envio)
        return ConvertSecureStringToString(securePassword);
    }

    /// <summary>
    /// Método para converter SecureString para string para realizar o envio corretamente do certificado.
    /// </summary>
    /// <param name="secureString"></param>
    /// <returns></returns>
    static string ConvertSecureStringToString(SecureString secureString)
    {
        IntPtr ptr = IntPtr.Zero;
        try
        {
            ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
            return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
        }
        finally
        {
            if (ptr != IntPtr.Zero)
                System.Runtime.InteropServices.Marshal.FreeBSTR(ptr);
        }
    }

    /// <summary>
    /// Método criado para envio do certificado para o ECAC.
    /// </summary>
    /// <param name="certPath"></param>
    /// <param name="pass"></param>
    /// <returns></returns>
    static async Task EnviarCertificado(string certPath, string pass)
    {
        try
        {
            X509Certificate2 certificado = new X509Certificate2(certPath, pass);

            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificates.Add(certificado);

            using (HttpClient client = new HttpClient(handler))
            {
                string url = "https://cav.receita.fazenda.gov.br/autenticacao/login";

                var parametros = new MultipartFormDataContent();
                parametros.Add(new StringContent(certPath), "pkcs12_cert");
                parametros.Add(new StringContent(pass), "pkcs12_pass");

                HttpResponseMessage response = await client.PostAsync(url, parametros);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nLogin realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nFalha ao realizar login.");
                }
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"\nErro na requisição: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nErro ao enviar certificado: {e.Message}");
        }
    }
}
