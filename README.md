# Admin Rooms

# Tabla de Contenidos
- [Descripción](#descripción)
- [Arquitectura](#arquitectura)
- [Requerimientos](#requerimientos)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Uso](#uso)
- [Contribución](#contribución)
- [Roadmap](#roadmap)

# Descripción
El proyecto tiene como objetivo desarrollar una aplicación llamada Admin Rooms, que se encuentra actualmente en la fase inicial. Esta aplicación, diseñada para arrendadores que gestionan múltiples propiedades o habitaciones, aspira a ofrecer un control preciso de las finanzas e inmuebles de los arrendadores. En su estado actual, Admin Rooms está planeada para incluir funcionalidades como la futura capacidad de registrar datos de clientes, realizar un seguimiento de los pagos, generar recibos digitales en formato PDF y permitirá realizar análisis detallados de ingresos y egresos mediante gráficas.

**¿Cual fue el problema identificado y la solucion?**

El problema que se identifico fue la capacidad de poca gestion sin una plataforma tecnologica, ya que anteriormente se utilizaban plataformas como excel o documentos a mano para poder organizar todo la gestion y esto era algo tedioso a la hora de buscar datos o medir el exito del proyecto, es por eso que opto por crear una aplicaicon la cual haga todos los procesos actuales pero mas autimatizados y de forma eficiente 


# Arquitectura

- ## ASP.NET
Esta app fue desarollada en C# con una arquitectura MVC, se implemento la inyeccion de dependencias, librerias externas y el uso de interfaces para mejorar la modularidad y mantenibilidad del codigo. Este enfoque permite escalabilidad y flexibilidad en el proyecto a futuro



# Requerimientos
## Servidores
### Aplicación
- **Azure**

    Opté por Azure como la solución para almacenar de forma segura los datos de la aplicación en la nube. Contraté un servidor en la plataforma para gestionar y almacenar eficientemente la información

### Web
- **IIS**

    Opte por publicar la aplicacion en un entorno local con IIS
### Bases de datos

- **SQL Server**

    Utilice SQL Server para desarrollar una base de datos solida y eficaz. Implementé constrains adecuados para prevenir posibles errores en la integridad de los datos.
# Paquetes adicionales
Para habilitar la generación de PDFs y la visualización de gráficos en la aplicación, se incorporaron dos librerías esenciales: **Rotativa** para la generación de PDFs y **Chart.js** para la creación de gráficos. Estas herramientas desempeñan un papel fundamental en el funcionamiento integral del sistema

# Versión de C#
 .NET 6

# Instalación
Desafortunadamente no puedo proveer los todos los pasos de instalacion ya que este proyecto fue para un cliente el cual pago por este producto, tambien esto es causa que algunos archivos del programa fueron removidos porque tenian la logica del programa, para ver el programa en accion pueden visitar el video publicado en [YouTube](https://youtu.be/9J0tTGvscnA)

Como mencione antes saltare algunos pasos de instalacion omitiendo alguno de ellos (mencionando cuales estoy omitiendo)

## Ambiente de Desarrollo

1. Crear una carpeta en *archivos* de la computadora donde quieras alojar el proyecto
2. En esa ubicacion de la carpeta creada, abre el CMD para ejecutar comandos 
3. Ejecuta el siguiente comando https://github.com/JairMora21/AdminRoomsProyect.git 
4. Se instalara el proyecto en nuestra carpeta creada 
5. Abrir el archivo el archivo con terminacion .SLN (Prerequisito: tener visual studio 2022 instalado con version minima de .NET 6)
6. Instalar SQL Server
7. Correr este *script* para genenar una base de datos (Script omitido por confidencialidad)
8. En el archivo *appsettings.json* modificar la cadena de conexion ConnectionString > SQL  ***"Data Source=Nombre_tu_Pc; Initial Catalog=Nombre_Tu_Bd; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultisubnetFailOver=False"***
9. Instalar los siguientes paquetes nuggets en visual studio 
- EntityFramework.tools
- EntityFramework.SQL
10. Correr el proyecto

## Ejecutar Pruebas
Para ejecutar las pruebas del proyecto es necesario seguir los pasos de instalacion y posteriormente realizar las pruebas dentro de la aplicacion 

## Implementación en Producción
1. En Visual Studio 2022 dar click en el boton de publicar 
2. Escoger un perfil y elegir la opcion de *carpeta*
3. Elegir la ruta donde se publicara la apicacion 
4. Darle click a publicar 
5. Abrir la aplicacion IIS en nuestro dispositivo
6. Agregar un nuevo sitio web
7. Seleccionar la carpeta del sitio web y el puerto donde se publicara 
8. Dar permisos necesarios a la carpeta 
9. Abrir la pagina 

# Configuración
## Configuración del Producto
Las configuraciones del producto serian las siguientes 
- Cambiar la cadena de conexion de SQL Server en appsettings.json en la app 

## Configuración de Requerimientos
Instrucciones adicionales de configuración.
- Contar con minimo .NET 6
- Instalar los paquetes nugget EntityFramework.tools y EntityFramework.SQL


# Uso
## Módulo de Login

### Iniciar Sesión

Para iniciar sesión en la aplicación, sigue estos sencillos pasos:

1. **Abrir la Página de Inicio de Sesión:**
   - Navega a la página principal de la aplicación. Encontrarás un botón o enlace que dice "Iniciar Sesión". Haz clic en este enlace para acceder al formulario de inicio de sesión.

2. **Ingresar Credenciales:**
   - Encontrarás dos campos de texto en la pantalla:
     - **Usuario:** Aquí debes ingresar tu nombre de usuario. Asegúrate de escribirlo correctamente.
     - **Contraseña:** Ingresa la contraseña asociada a tu cuenta. Recuerda que la contraseña es sensible a mayúsculas y minúsculas, así que debes ingresarla exactamente como la configuraste.

3. **Iniciar Sesión:**
   - Una vez que hayas ingresado tus credenciales, presiona el botón "Iniciar Sesión" para acceder a tu cuenta.
   - Si los datos son correctos, serás redirigido a la página principal de la aplicación. Si hay algún error, se mostrará un mensaje indicando el problema (por ejemplo, "Usuario o contraseña incorrectos").

## Pagina principal 
Para ver todos los modulos de la aplicacion debera hacer click en las 3 barras para desplegar el navbar, en este podra ver reflejado los modulos de la aplicacion las cuales seran  

## Modulo Huespedes 
### Descripción General

El módulo de Huéspedes en nuestra aplicación permite gestionar toda la información relacionada con los huéspedes de manera eficiente y efectiva. Con este módulo, puedes crear nuevos registros de huéspedes, ver detalles de huéspedes existentes, actualizar su información o eliminar registros que ya no sean necesarios.

### Crear un Nuevo Huésped

1. **Acceder al Formulario de Nuevo Huésped:**
   - Navega a la sección de Huéspedes desde el menú principal y selecciona la opción "Agregar Nuevo Huésped".

2. **Completar el Formulario:**
   - Completa el formulario con la información del huésped, incluyendo nombre, apellido, información de contacto, y cualquier otro campo requerido.
   - Asegúrate de revisar que la información esté correcta y completa.

3. **Guardar el Registro:**
   - Una vez completado el formulario, haz clic en el botón "Guardar" para crear el nuevo registro de huésped.

### Leer (Ver Detalles del Huésped)

1. **Buscar Huésped:**
   - La pagina principal de este modulo te dara la vista de los huespedes.

2. **Ver Detalles:**
   - Haz clic en el boton del 'ojito'  para abrir una ventana con todos los detalles del registro.
   - Aquí puedes revisar toda la información asociada al huésped.

### Actualizar Información del Huésped

1. **Seleccionar el Huésped:**
   - Dentro de la lista de huéspedes, haz clic en el botón "Editar" junto al huésped que deseas actualizar.

2. **Modificar la Información:**
   - Cambia la información necesaria en el formulario que aparece.
   - Puedes editar campos como el nombre, contacto, dirección, y más.

3. **Guardar Cambios:**
   - Después de hacer las modificaciones, presiona el botón "Actualizar" para guardar los cambios.

### Eliminar un Huésped

1. **Seleccionar el Huésped:**
   - Localiza al huésped que deseas eliminar en la lista de huéspedes.

2. **Eliminar Huésped:**
   - Haz clic en el botón "Eliminar" junto al nombre del huésped.
   - Confirmar la acción si se requiere para proceder con la eliminación del registro.

   ---------

## Módulo de Cuartos

### Descripción General

El módulo de Cuartos en nuestra aplicación es un sistema integral para la gestión de propiedades que incluye la creación, lectura, actualización, eliminación y asignación de huéspedes a estas propiedades. A continuación, se describen las funcionalidades disponibles.

### Registro de Cuartos

1. **Crear un Nuevo Cuarto:**
   - Navega a la sección de Cuartos desde el menú principal y selecciona "Agregar Nuevo Cuarto".
   - Completa el formulario con la información requerida, como el nombre o número del cuarto y su costo.
   - Haz clic en "Guardar" para crear el registro del nuevo cuarto.

2. **Ver Detalles del Cuarto:**
   - En la lista de cuartos, puedes ver todos los detalles haciendo clic sobre el nombre del cuarto deseado.
   - Esta acción mostrará una página con toda la información detallada del cuarto.

3. **Actualizar Información del Cuarto:**
   - Busca el cuarto que deseas editar y haz clic en el botón "Editar".
   - Modifica la información necesaria y confirma los cambios guardando la actualización.

4. **Eliminar un Cuarto:**
   - Si necesitas eliminar un cuarto, selecciona el botón "Eliminar" correspondiente.
   - Se solicitará confirmación para asegurar que deseas proceder con la eliminación.

### Asignación y Liberación de Huéspedes

1. **Asignar Huéspedes a Cuartos Disponibles:**
   - En la lista de cuartos, aquellos que estén disponibles mostrarán un botón "Asignar".
   - Al hacer clic en "Asignar", se desplegará una lista de huéspedes sin asignar.
   - Selecciona un huésped y confirma la asignación para asociar el huésped con el cuarto disponible.

2. **Liberar Cuartos Ocupados:**
   - Para cuartos que están actualmente ocupados, encontrarás un botón "Liberar".
   - Al hacer clic, se te pedirá confirmar la acción de liberar el cuarto y desvincular al huésped asignado.

### Lista de Cuartos con Disponibilidad

- La sección principal del módulo de Cuartos mostrará una lista completa de todas las propiedades, junto con su estado de disponibilidad:
  - **Ocupado:** El cuarto está actualmente ocupado por un huésped.
  - **Disponible:** El cuarto está disponible para asignar a un nuevo huésped.

## Módulo de Finanzas

### Descripción General

El módulo de Finanzas en nuestra aplicación está diseñado para gestionar de manera integral los aspectos financieros del negocio. Este módulo se divide en tres submódulos principales: Asignaciones, Gastos y Finanzas, cada uno con funcionalidades específicas para facilitar la administración efectiva de los recursos económicos.

### Submódulo de Asignaciones

### Visualización de Asignaciones

1. **Tabla de Asignaciones:**
   - En este submódulo, encontrarás una tabla que muestra todas las asignaciones de clientes a propiedades.
   - La tabla incluye información básica como el nombre y apellido del cliente, el número o nombre de la propiedad, la fecha de ingreso, la finalización del contrato y la fecha del último pago.
   - Una columna adicional mostrará el estado de pago, que puede ser "PAGADO" o "NO PAGADO" dependiendo de si el pago está al día según los criterios establecidos.

### Generación de Pago

1. **Proceso de Pago:**
   - Dentro de la tabla de asignaciones, cada registro incluirá un botón "Generar Pago".
   - Al hacer clic en este botón, accederás a una interfaz donde podrás generar un nuevo pago.
   - La interfaz de pago incluirá datos prellenados del cliente, la fecha actual y campos para ingresar el concepto del pago y el tipo de pago (efectivo, transferencia, retiro sin tarjeta).

2. **Finalización del Pago:**
   - Se ofrecerán dos opciones: un botón para simplemente generar y guardar el pago y otro botón que, además de guardar el pago, generará un recibo en formato PDF con los datos ingresados.

### Condición de Pago Mensual

- La columna de estado de pago se actualizará automáticamente:
  - Se mostrará como "PAGADO" si el último pago registrado es menor a un mes desde la fecha actual.
  - Se mostrará como "NO PAGADO" si el último pago registrado es mayor a un mes desde la fecha actual.

Estas funcionalidades aseguran una gestión eficiente de los pagos y asignaciones, facilitando el seguimiento y la actualización de los estados financieros de los clientes y las propiedades.

### Submódulo de Gastos

### Descripción General

El submódulo de Gastos está diseñado para gestionar todos los gastos asociados con la operación de la entidad. Se divide en tres categorías principales: Gastos Variables, Gastos Fijos y Gastos Semi-Fijos, permitiendo un registro detallado y seguimiento de cada tipo de gasto.

### 1. Gastos Variables

1.1 **Registro de Gastos Variables:**
   - Para registrar un gasto variable, accede a la sección de Gastos Variables y selecciona "Agregar Nuevo Gasto".
   - Deberás proporcionar detalles como el nombre del gasto, el monto y la fecha en que se realizó.
   - Estos gastos son esporádicos y no tienen una periodicidad fija.

### 2. Gastos Fijos

2.1 **Registro de Gastos Fijos:**
   - Los gastos fijos se registran accediendo a la sección de Gastos Fijos y seleccionando "Agregar Gasto Fijo".
   - Ingresa el nombre del gasto, el monto y la fecha de vencimiento del pago.
   - La aplicación mantendrá una lista de todos los gastos fijos, con opciones para editarlos, eliminarlos o registrar sus pagos.

2.2 **Registro de Pagos para Gastos Fijos:**
   - Para cada gasto fijo, podrás registrar el pago especificando el monto pagado y la fecha de pago.
   - El sistema mostrará si el gasto está "pagado" o "no pagado" basado en si la fecha de pago es posterior a la fecha de vencimiento.

### 3. Gastos Semi-Fijos

3.1 **Registro de Gastos Semi-Fijos:**
   - En la sección de Gastos Semi-Fijos, selecciona "Agregar Gasto Semi-Fijo".
   - Completa el registro con el nombre del gasto y otros detalles necesarios, teniendo en cuenta que el monto puede variar en cada período de facturación.

3.2 **Gestión de Pagos para Gastos Semi-Fijos:**
   - La lista de gastos semi-fijos permitirá editar, eliminar y registrar pagos.
   - Al registrar un pago, especifica el monto pagado y confirma el registro del pago.

### Submódulo de Finanzas

### Descripción General

El submódulo de Finanzas está diseñado para proporcionar un seguimiento detallado y una gestión eficiente de los ingresos y egresos. Ofrece funcionalidades avanzadas para la generación de reportes y la administración de movimientos financieros.

### 1. Reportes de Ingresos y Egresos

1.1 **Intervalo de Fechas:**
   - Accede a la sección de Reportes desde el menú de Finanzas.
   - Selecciona un intervalo de fechas (inicio y final) para visualizar los reportes.
   - Al establecer las fechas, se generarán automáticamente dos gráficas: una que muestra los ingresos y egresos y otra en formato pastel de división de tipos de gastos.

1.2 **Gráfica de Ingresos y Egresos:**
   - Esta gráfica detalla el total de ingresos obtenidos y los gastos realizados en el intervalo seleccionado.
   - Además, se presentará un balance general que muestra la diferencia entre ingresos y gastos.

1.3 **Gráfica Pastel de División de Gastos:**
   - La gráfica en formato pastel mostrará cómo se dividen los gastos entre variables, fijos y semi-fijos.
   - Esta visualización ayuda a identificar rápidamente las áreas de mayor gasto.

### 2. Ingresos

2.1 **CRUD de Recibos:**
   - En la sección de Ingresos, podrás gestionar todos los recibos generados.
   - Cada recibo listado incluirá detalles como el nombre del cliente, el monto, la fecha de generación y el tipo de pago.
   - Desde aquí, los recibos pueden ser editados, eliminados o consultados en detalle.

### 3. Egresos

3.1 **CRUD de Gastos:**
   - Similar a los ingresos, la sección de Egresos permite la gestión completa de todos los gastos registrados.
   - Cada gasto mostrado en la lista contendrá información como el nombre del gasto, monto, fecha y tipo de gasto.
   - Opciones para editar, eliminar y ver detalles de cada gasto están disponibles para facilitar la administración.



## Usuario Administrador
No existira un usuario para administrador ya que esta aplicacion esta pensada para un tipo de usuario, no hay roles dentro de la app

## Guía de Contribución

Sigue estos pasos para contribuir de manera efectiva.

### Pasos para Contribuir

### 1. Clonar el Repositorio
Para comenzar, necesitarás tener una copia local del repositorio. Abre tu terminal y ejecuta el siguiente comando:
- https://github.com/JairMora21/AdminRoomsProyect.git

### 2. Crear un Nuevo Branch
Es una buena práctica crear un branch para cada nueva característica o corrección. Esto mantiene las modificaciones organizadas y separadas del branch principal. Desde tu terminal, cambia al directorio del repositorio y ejecuta:

- cd repositorio
- git checkout -b nombre-del-branch

Reemplaza `nombre-del-branch` con un nombre descriptivo para tu branch, por ejemplo, `funcionalidad-nueva` o `correccion-bug`.

### 3. Realizar Cambios
Realiza los cambios necesarios en tu branch. Asegúrate de seguir las guías de estilo del proyecto. Una vez que termines, añade los cambios al índice:

- git add .
Y luego confirma los cambios:
- git commit -m "Añadir una descripción detallada de los cambios realizados"

### 4. Enviar el Pull Request
Antes de enviar un pull request, asegúrate de sincronizar tu repositorio con el principal para incorporar cualquier cambio reciente:

- git fetch origin
- git rebase origin/main

Luego, desde tu branch, empuja tus cambios al repositorio remoto:

 - git push origin nombre-del-branch

Ve al repositorio en GitHub, y encontrarás un botón para 'Crear pull request'. Sigue las instrucciones en pantalla para crear el pull request.

### 5. Esperar a hacer el Merge
Una vez enviado el pull request, espera a que el mantenedor del proyecto revise tus cambios. Podrían pedirte que realices modificaciones adicionales. Una vez que tu pull request sea aprobado, el mantenedor hará el merge de tus cambios con el branch principal. ¡Felicidades, has contribuido al proyecto!

# Roadmap

A medida que nuestro proyecto evoluciona, tenemos planificado implementar varias mejoras y nuevas características para enriquecer la funcionalidad y la usabilidad de la aplicación. Estos son los requerimientos que planeamos abordar en el futuro:

## 1. Expansión de Funcionalidades
Actualmente, la aplicación permite agregar propiedades básicas. Planeamos expandir estas capacidades para incluir una gama más amplia de propiedades y características personalizables, permitiendo a los usuarios adaptar la aplicación a sus necesidades específicas.

## 2. Integración de Pasarela de Pago
Para mejorar la experiencia del usuario y facilitar transacciones seguras y eficientes, implementaremos una pasarela de pago. Esto permitirá a los clientes realizar pagos en línea directamente desde la aplicación, soportando múltiples métodos de pago para aumentar la accesibilidad y conveniencia.

## 3. Diseño Responsivo
Reconociendo la importancia del acceso móvil, haremos que la aplicación sea completamente responsiva. Esto asegurará que la aplicación sea compatible y fácil de usar en dispositivos móviles, mejorando la experiencia del usuario en smartphones y tablets.
