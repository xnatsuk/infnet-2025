import java.io.*;
import java.util.Scanner;


public class RegistroCompras {
    public static void main(String[] args) {
        String arquivo = "compras.txt";

        salvarCompra(arquivo);
        listarCompras(arquivo);
    }

    public static void listarCompras(String arquivo) {
        try {
            System.out.println("\n----- Compras Registradas -----");

            FileReader fileReader = new FileReader(arquivo);
            BufferedReader bufferedReader = new BufferedReader(fileReader);

            String linha;
            while ((linha = bufferedReader.readLine()) != null) {
                System.out.println(linha);
            }

            bufferedReader.close();

        } catch (IOException e) {
            System.out.println("Erro ao ler o arquivo " + e.getMessage());
        }
    }

    public static void salvarCompra(String arquivo) {
        Scanner input = new Scanner(System.in);

        try {
            FileWriter fileWriter = new FileWriter(arquivo);
            PrintWriter printWriter = new PrintWriter(fileWriter);

            for (int i = 1; i <= 3; i++) {
                System.out.println("\nCadastro da compra " + i);

                System.out.print("Nome do produto: ");
                String produto = input.nextLine();

                System.out.print("Quantidade: ");
                int quantidade = Integer.parseInt(input.nextLine());

                System.out.print("Preço unitário: R$ ");
                double precoUnitario = Double.parseDouble(input.nextLine());

                printWriter.printf("%s,%d,%2f\n", produto, quantidade, precoUnitario);

                System.out.printf("""
                                Compra registrada: %s\
                                
                                %d unidades\
                                
                                R$ %.2f cada\
                                
                                """,
                        produto, quantidade, precoUnitario);

            }

            printWriter.close();
            System.out.println("\nCompras salvas com sucesso.");

        } catch (IOException e) {
            System.out.println("Erro ao salvar o arquivo " + e.getMessage());
        }

        input.close();
    }
}
