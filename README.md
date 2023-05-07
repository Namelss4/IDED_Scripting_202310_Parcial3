# Parcial 3: Patrones de diseño
 
## Jerónimo Cano Álvarez ID 000165440 & Carolina Arboleda Arboleda ID 000165774
 
A gran parte de las clases se les aplica el patrón Singleton, realmente no se tocan las clases base (dado que se corrigió el error que descubrimos). 

En la escena se crea un objeto padre llamado PoolParent, quien tiene como hijos a seis Game Objects, tres para las pools de las balas y tres para las pools de los obstáculos. Estos objetos podrían ser prefabs, pues se usan para poder asignarselos a los scripts Refactored Player Controller y Refactored Obstacle Spawner.

Existe una interfaz IObservable que fue utilizada para el envío de mensajes entre los obstáculos al ser destruidos y el game controller para actualizar el marcador, al final se optó por implementar el patrón de observers de una manera diferente (como originalmente se había explicado en clase), por lo que la interfaz termina siendo posiblemente obviable.

Todas las clases de pools como las tres de balas y las tres de obstáculos heredan de la clase PoolBase, la cual es la encargada de manejar la gran mayoría de sus métodos, como se puede ver en el código.

Se presentaron muchos inconvenientes, como es notable al revisar el proyecto. La forma que tiene el pooling de hacer el retrieve no permite instanciar los objetos de formas diferentes, por lo que tanto los obstáculos como las balas se instancian en el método PopulatePool y se reciclan adecuadamente. Tras esto, cuando las funciones encargadas de traer objetos de dichas pools (RetrieveInstance) sean llamadas, dichos objetos aparecen en la mitad de la pantalla. Los obstáculos caen por la gravedad, pero las balas se quedan en medio de la pantalla. 

Para ejectuar con éxito el método RecycleInstance existieron múltiples problemas, por ejemplo, la colisión con el kill volume se estaba dando pero no destruía ningún gameobject, al aplicar el pooling se intentó que se llamara al RecycleInstance, pero no funcionó. Las balas, al no moverse, no cumplían su condición para ser recicladas, por lo que no se pudo implementar correctamente el método.

Hubo muchos problemas en todas partes, cuando algo parecía ir por un buen camino aparecían otras diez cosas a las que prestarle atención. La documentación y el material de apoyo que se buscó iba por lados muy extraños y terminaba pareciendo inaplicable a muchos de los casos tan específicos que se necesitaban. La implementación del patrón observers parecía ir bien, pero cuando ya parecía totalmente resuelta apareció un problema todavía mayor, todo se volvió muy complejo, sobrecogedor y difícil de mantener en la cabeza, habían millones de cosas por solucionar y todo parecía ir a peor. Tras muchos intentos, un miembro del equipo sufrió de un ataque de pánico y fue incapaz de continuar. Como se verá, siempre se ha intentado hacer lo mejor posible, en los parciales pasados se logró llegar a algo satisfactorio, pero ahora es físicamente imposible seguir adelante, perdón.
