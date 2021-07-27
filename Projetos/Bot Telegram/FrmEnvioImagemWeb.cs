using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace BotTelegram1
{
    public partial class FrmEnvioImagemWeb : Form
    {
        public FrmEnvioImagemWeb()
        {
            InitializeComponent();
        }

        private void FrmEnvioImagemWeb_Load(object sender, EventArgs e)
        {

        }

        private async void btnEnviar_ClickAsync(object sender, EventArgs e)
        {

            if (txtUrlImagem.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Informe a URL da mensagem para o envio!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var telegramBot = new TelegramBotClient("1755387732:AAHWVTH6AeabrHiEA2R73OUK52oN6gZw9i0");
                var imageRequest = WebRequest.Create(txtUrlImagem.Text.Trim());

                using (var imagemResponse = imageRequest.GetResponse())
                {
                    var stream = imagemResponse.GetResponseStream();
                    await telegramBot.SendPhotoAsync(chatId: "-1001506779457", photo: stream, caption: txtMensagem.Text.Trim(), parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
                }



                MessageBox.Show("Mensagem enviada com sucesso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar a mensagem!!" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                txtMensagem.Text = string.Empty;
                txtUrlImagem.Text = string.Empty;
            }






        }
    }
}
