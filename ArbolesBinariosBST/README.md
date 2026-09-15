# Sistema de Árboles Binarios de Búsqueda

Proyecto desarrollado en C# y .NET para representar, visualizar y consultar árboles binarios de búsqueda (BST) a partir de datos almacenados en archivos de texto.

## Descripción

El programa permite cargar dos conjuntos de datos desde archivos `.txt` y construir automáticamente un árbol binario de búsqueda respetando la propiedad de que los valores menores se ubican en el subárbol izquierdo y los valores mayores en el subárbol derecho.

## Funcionalidades

- Carga de datos desde archivos de texto.
- Construcción de árboles binarios de búsqueda.
- Representación gráfica del árbol en consola.
- Recorrido inorden.
- Recorrido preorden.
- Recorrido postorden.
- Búsqueda de valores.
- Obtención del valor mínimo y máximo.
- Cálculo de la altura del árbol.
- Conteo del número total de nodos.
- Conteo del número de hojas.
- Medición del tiempo de carga y construcción del árbol.
- Menú interactivo para seleccionar los ejemplos.

## Archivos de entrada

El proyecto utiliza dos archivos:

- `arbol1.txt`: contiene 7 valores para construir el primer BST.
- `arbol2.txt`: contiene 11 valores para construir el segundo BST.

## Tecnologías utilizadas

- C#
- .NET
- Visual Studio Code

## Ejecución

Para ejecutar el proyecto desde la terminal:

```bash
dotnet run