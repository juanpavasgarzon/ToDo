# ToDo Application

## Descripción

Esta aplicación es un gestor de tareas (ToDo) diseñado para ayudar a los usuarios a organizar y gestionar sus tareas diarias de manera eficiente. La aplicación está construida con una arquitectura de microservicios, utilizando tecnologías modernas para garantizar escalabilidad y rendimiento.

## Estructura del Proyecto

El proyecto está dividido en los siguientes módulos:

- **ToDo.API**: Contiene las API para la comunicación con el frontend.
- **ToDo.Application**: Maneja la lógica de la aplicación.
- **ToDo.Domain**: Define las entidades y reglas de negocio.
- **ToDo.Front**: El frontend de la aplicación.
- **ToDo.Infrastructure**: Configuraciones y servicios de infraestructura.

## Tecnologías Utilizadas

- **Lenguaje de programación**: C# .NET
- **Frontend**: Blazor
- **Contenedores**: Docker

## Configuración

Para configurar y ejecutar la aplicación localmente:

1. Clonar el repositorio:
    ```sh
    git clone https://github.com/juanpavasgarzon/ToDo.git
    ```
2. Navegar al directorio del proyecto:
    ```sh
    cd ToDo
    ```
3. Configurar y levantar los contenedores de Docker:
    ```sh
    docker-compose up -d --build
    ```

## Contribuciones

Las contribuciones son bienvenidas. Para contribuir, por favor sigue los siguientes pasos:

1. Haz un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-feature`).
3. Realiza los cambios necesarios y haz commits (`git commit -m 'Agrega nueva feature'`).
4. Sube tus cambios a tu fork (`git push origin feature/nueva-feature`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Para preguntas o comentarios, puedes contactar al autor del proyecto a través de su perfil de GitHub: [juanpavasgarzon](https://github.com/juanpavasgarzon).
