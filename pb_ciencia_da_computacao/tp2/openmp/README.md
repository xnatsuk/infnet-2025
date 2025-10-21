# Parte C — OpenMP

## Estrutura do Projeto

- `monte_carlo_pi.c` - Estimativa de π com Monte Carlo paralelo
- `Dockerfile` - Dockerfile para ambiente OpenMP
- `docker-compose.yml` - Configuração do Docker Compose
- `Makefile` - Compilação

## Como Usar

### 1. Iniciar o ambiente Docker

```bash
docker-compose up -d
docker-compose exec openmp bash
```

### 2. Executar testes

```bash
make test
```

### 3. Limpar arquivos compilados

```bash
make clean
```

## Sair do Container

```bash
exit
docker-compose down
```