using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    private static readonly Dictionary<Type, Delegate> eventTable = new();

    /// <summary>
    /// Suscribe un callback al evento del tipo <typeparamref name="T"/>.
    /// Si ya existen suscriptores para este tipo, agrega el nuevo callback.
    /// </summary>
    /// <typeparam name="T">Tipo de evento al que se suscribe.</typeparam>
    /// <param name="callback">Método que será llamado cuando se lance el evento.</param>
    public static void Subscribe<T>(Action<T> callback) where T : class
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
        {
            eventTable[typeof(T)] = Delegate.Combine(del, callback);
        }
        else
        {
            eventTable[typeof(T)] = callback;
        }
    }

    /// <summary>
    /// Elimina un callback suscrito al evento del tipo <typeparamref name="T"/>.
    /// Si después de eliminar no quedan más suscriptores, elimina la entrada de la tabla.
    /// </summary>
    /// <typeparam name="T">Tipo de evento del que se desuscribe.</typeparam>
    /// <param name="callback">Método que será removido de la suscripción.</param>
    public static void Unsubscribe<T>(Action<T> callback) where T : class
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
        {
            var newDel = Delegate.Remove(del, callback);
            if (newDel == null)
            {
                eventTable.Remove(typeof(T));
            }
            else
            {
                eventTable[typeof(T)] = newDel;
            }
        }
    }

    /// <summary>
    /// Lanza (invoca) el evento del tipo <typeparamref name="T"/>, llamando a todos los callbacks suscritos.
    /// </summary>
    /// <typeparam name="T">Tipo de evento a lanzar.</typeparam>
    /// <param name="evt">Instancia del evento a enviar a los suscriptores.</param>
    public static void Raise<T>(T evt) where T : class
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
        {
            ((Action<T>)del)?.Invoke(evt);
        }
    }
}
