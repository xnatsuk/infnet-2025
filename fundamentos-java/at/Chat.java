import java.util.Scanner;

public class Chat {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("----- Chat Simples -----");

        System.out.print("Nome do primeiro usuário: ");
        String usuario1 = input.nextLine();

        System.out.print("Nome do segundo usuário: ");
        String usuario2 = input.nextLine();

        String[] mensagens = new String[10];

        for (int i = 0; i < mensagens.length; i++) {
            String usuarioAtual = (i % 2 == 0) ? usuario1 : usuario2; // alterna os usuarios

            System.out.printf("\n%s, digite sua mensagem: ", usuarioAtual);
            String mensagem = input.nextLine();

            mensagens[i] = usuarioAtual + ": " + mensagem;
        }

        System.out.println("\n----- Histórico de Mensagens -----");
        for (String mensagem : mensagens) {
            System.out.println(mensagem);
        }
        
        System.out.println("\nObrigado por utilizarem o sistema! Boa sorte para vocês! 🚀");
        input.close();
    }
}
