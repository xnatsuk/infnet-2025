import java.util.Scanner;

public class Senha {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String senha;
        String senha_2;

        System.out.print("Digite sua senha: ");
        senha = input.nextLine();

        do {
            System.out.print("Confirme sua senha: ");
            senha_2 = input.nextLine();

            if (!senha_2.equals(senha)) {
                System.out.println("[Senha Incorreta] Tente novamente.");
            }
        } while (!senha_2.equals(senha));

        System.out.println("[Senha Correta]");
        input.close();
    }
}
