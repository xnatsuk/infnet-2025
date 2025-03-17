public class Figuras {
    public static void main(String[] args) {
        Circulo circulo = new Circulo(3.0);
        Esfera esfera = new Esfera(5.0);

        double area = circulo.calcularArea();
        double volume = esfera.calcularVolume();

        // valor formatado
        System.out.printf("Area Circulo: %.2f", area);
        System.out.printf("\nVolume Esfera: %.2f", volume);
    }
}

class Circulo {
    double raio;

    Circulo(double raio) {
        this.raio = raio;
    }

    double calcularArea() {
        return Math.PI * raio * raio;
    }
}

class Esfera {
    double raio;

    Esfera(double raio) {
        this.raio = raio;
    }

    double calcularVolume() {
        return (4.0 / 3.0) * Math.PI * raio * raio * raio;
    }
}
