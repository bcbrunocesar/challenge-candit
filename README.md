# Desafio CI&T
Objetivo

Criar servi�o onde o corretor informa os
dados b�sicos do futuro segurado e a lista de coberturas nas quais o segurado est�
interessado.

Retornar com base nas informa��es concebidas o _valor do pr�mio_, _parcelas_, _valor das parcelas_, _primeiro vencimento_ e o _valor total da cobertura_.


## Servi�os dispon�veis
`/v1/price` `[Post]`
`/v1/cities` `[Get]`

## Exemplos
`/v1/price`

##### Requisi��o v�lida
![diagram](docs/exemplos/post-valid.jpg)

##### Retorno
![diagram](docs/exemplos/post-valid-200.jpg)

---

##### Requisi��o inv�lida
![diagram](docs/exemplos/post-invalid.jpg)

##### Retorno
![diagram](docs/exemplos/post-invalid-200.jpg)


Desenvolvido por Bruno Farias.