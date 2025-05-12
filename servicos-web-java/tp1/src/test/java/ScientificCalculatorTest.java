import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Tag;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.*;

class ScientificCalculatorTest {
    private ScientificCalculator calculator;

    // 4. Test Fixture com BeforeEach
    @BeforeEach
    void setUp() {
        calculator = new ScientificCalculator();
    }

    // 2. Escrevendo o primeiro teste
    @DisplayName("Teste de Adição")
    @Tag("simples")
    @Test
    void testAddition() {
        assertEquals(70, calculator.add(22, 48), "O resultado de 22 + 48 deve ser igual a 70");
    }

    // 3. Aplicando as 4 fases de um teste
    @DisplayName("Teste de Subtração")
    @Tag("simples")
    @Test
    void testSubtract() {
        // Setup - realizado antes de cada teste (@BeforeEach)

        // Execution & Assertion (inline)
        assertEquals(45, calculator.subtract(100, 55), "O resultado de 100 - 55 deve ser igual a 45");

        // Teardown - realizado pelo JUnit
    }

    @DisplayName("Teste de Multiplicação")
    @Test
    @Tag("simples")
    void testMultiply() {
        assertEquals(15, calculator.multiply(5, 3), "O resultado de 15 * 3 deve ser igual a 15");
    }

    @DisplayName("Teste de Divisão")
    @Tag("simples")
    @Test
    void testDivide() {
        assertEquals(4, calculator.divide(20, 5), "O resultado de 20 / 5 deve ser igual a 4");
    }

    @DisplayName("Teste de Exponenciação")
    @Tag("avançado")
    @Test
    void testPower() {
        assertEquals(8, calculator.power(2, 3), "O resultado de 2 ^ 3 deve ser igual a 8");
    }

    // 5. Testando um cenário de sucesso (Happy Path)
    @DisplayName("Teste de Raiz Quadrada Positiva")
    @Tag("avançado")
    @Test
    void testSquareRootPositive() {
        assertEquals(10, calculator.squareRoot(100), "O resultado da raiz quadrada de 100 deve ser igual a 10");
    }

    // Experimentando o @ParameterizedTest
    @DisplayName("Teste de Logaritmos Positivos")
    @Tag("avançado")
    @ParameterizedTest
    @CsvSource({
            Math.E + " , 1.0",
            "1.0, 0.0"
    })
    void testLogPositive(double input, double expected) {
        assertEquals(expected, calculator.log(input), "Log de " + input + " deve ser próximo de " + expected);
    }

    @DisplayName("Teste Trigonometria - Seno Com Ângulos Retos")
    @Tag("trigonometria")
    @ParameterizedTest
    @CsvSource({
            "90.0, 1.0",
            "270.0, -1.0",
            "-90.0, -1.0",
    })
    void testSinWithRightAngles(double input, double expected) {
        assertEquals(expected, calculator.sin(input), "Seno de " + input + " graus deve ser próximo de " + expected);
    }

    @DisplayName("Teste Trigonometria - Cosseno Com Ângulos Retos")
    @Tag("trigonometria")
    @ParameterizedTest
    @CsvSource({
            "0.0, 1.0",
            "180.0, -1.0",
    })
    void testCosWithRightAngles(double input, double expected) {
        assertEquals(expected, calculator.cos(input), "Cosseno de " + input + " graus deve ser próximo de " + expected);
    }

    // 6. Testando um cenário patológico (Corner Case)
    @DisplayName("Teste de Raiz Quadrada Negativa")
    @Tag("exceção")
    @Test
    void testSquareRootNegative() {
        Exception exception = assertThrows(IllegalArgumentException.class, () -> {
            calculator.squareRoot(-1.0);
        });
        assertTrue(exception.getMessage().contains("Negative number"));
    }

    // 7. Cenário de exceção (divisão por zero)
    @DisplayName("Teste de Divisão Por Zero")
    @Tag("exceção")
    @Test
    void testDivideByZero() {
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.divide(20, 0);
        });
    }

    @DisplayName("Teste de Logaritmos Não Positivos")
    @Tag("exceção")
    @Test
    void testLogNonPositive() {
        assertThrows(IllegalArgumentException.class, () -> {
            calculator.log(0);
        });

        assertThrows(IllegalArgumentException.class, () -> {
            calculator.log(-2);
        });
    }
}
