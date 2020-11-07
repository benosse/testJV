/**
 * Copyright (c) 2020 Enzien Audio, Ltd.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions, and the following disclaimer.
 * 
 * 2. Redistributions in binary form must reproduce the phrase "powered by heavy",
 *    the heavy logo, and a hyperlink to https://enzienaudio.com, all in a visible
 *    form.
 * 
 *   2.1 If the Application is distributed in a store system (for example,
 *       the Apple "App Store" or "Google Play"), the phrase "powered by heavy"
 *       shall be included in the app description or the copyright text as well as
 *       the in the app itself. The heavy logo will shall be visible in the app
 *       itself as well.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions;
using AOT;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Hv_metronome_AudioLib))]
public class Hv_metronome_Editor : Editor {

  [MenuItem("Heavy/metronome")]
  static void CreateHv_metronome() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_metronome_AudioLib>();
    }
  }

  private Hv_metronome_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_metronome_AudioLib;
  }

  public override void OnInspectorGUI() {
    bool isEnabled = _dsp.IsInstantiated();
    if (!isEnabled) {
      EditorGUILayout.LabelField("Press Play!",  EditorStyles.centeredGreyMiniLabel);
    }
    GUILayout.BeginVertical();
    
    // PARAMETERS
    GUI.enabled = true;
    EditorGUILayout.Space();
    EditorGUI.indentLevel++;

    // metroIO
    GUILayout.BeginHorizontal();
    float metroIO = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Metroio);
    float newMetroio = EditorGUILayout.Slider("metroIO", metroIO, 0.0f, 1.0f);
    if (metroIO != newMetroio) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Metroio, newMetroio);
    }
    GUILayout.EndHorizontal();

    // metroReset
    GUILayout.BeginHorizontal();
    float metroReset = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Metroreset);
    float newMetroreset = EditorGUILayout.Slider("metroReset", metroReset, 0.0f, 1.0f);
    if (metroReset != newMetroreset) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Metroreset, newMetroreset);
    }
    GUILayout.EndHorizontal();

    // resetByMesure
    GUILayout.BeginHorizontal();
    float resetByMesure = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Resetbymesure);
    float newResetbymesure = EditorGUILayout.Slider("resetByMesure", resetByMesure, 0.0f, 5000.0f);
    if (resetByMesure != newResetbymesure) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Resetbymesure, newResetbymesure);
    }
    GUILayout.EndHorizontal();

    // setBpm
    GUILayout.BeginHorizontal();
    float setBpm = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setbpm);
    float newSetbpm = EditorGUILayout.Slider("setBpm", setBpm, 0.0f, 300.0f);
    if (setBpm != newSetbpm) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setbpm, newSetbpm);
    }
    GUILayout.EndHorizontal();

    // setPeriodeBlanche
    GUILayout.BeginHorizontal();
    float setPeriodeBlanche = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodeblanche);
    float newSetperiodeblanche = EditorGUILayout.Slider("setPeriodeBlanche", setPeriodeBlanche, 0.0f, 5000.0f);
    if (setPeriodeBlanche != newSetperiodeblanche) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodeblanche, newSetperiodeblanche);
    }
    GUILayout.EndHorizontal();

    // setPeriodeCroche
    GUILayout.BeginHorizontal();
    float setPeriodeCroche = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodecroche);
    float newSetperiodecroche = EditorGUILayout.Slider("setPeriodeCroche", setPeriodeCroche, 0.0f, 5000.0f);
    if (setPeriodeCroche != newSetperiodecroche) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodecroche, newSetperiodecroche);
    }
    GUILayout.EndHorizontal();

    // setPeriodeDbCroche
    GUILayout.BeginHorizontal();
    float setPeriodeDbCroche = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodedbcroche);
    float newSetperiodedbcroche = EditorGUILayout.Slider("setPeriodeDbCroche", setPeriodeDbCroche, 0.0f, 5000.0f);
    if (setPeriodeDbCroche != newSetperiodedbcroche) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodedbcroche, newSetperiodedbcroche);
    }
    GUILayout.EndHorizontal();

    // setPeriodeMesure
    GUILayout.BeginHorizontal();
    float setPeriodeMesure = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodemesure);
    float newSetperiodemesure = EditorGUILayout.Slider("setPeriodeMesure", setPeriodeMesure, 0.0f, 5000.0f);
    if (setPeriodeMesure != newSetperiodemesure) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodemesure, newSetperiodemesure);
    }
    GUILayout.EndHorizontal();

    // setPeriodeNoire
    GUILayout.BeginHorizontal();
    float setPeriodeNoire = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodenoire);
    float newSetperiodenoire = EditorGUILayout.Slider("setPeriodeNoire", setPeriodeNoire, 0.0f, 5000.0f);
    if (setPeriodeNoire != newSetperiodenoire) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodenoire, newSetperiodenoire);
    }
    GUILayout.EndHorizontal();

    // setPeriodeQdCroche
    GUILayout.BeginHorizontal();
    float setPeriodeQdCroche = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodeqdcroche);
    float newSetperiodeqdcroche = EditorGUILayout.Slider("setPeriodeQdCroche", setPeriodeQdCroche, 0.0f, 5000.0f);
    if (setPeriodeQdCroche != newSetperiodeqdcroche) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodeqdcroche, newSetperiodeqdcroche);
    }
    GUILayout.EndHorizontal();

    // setPeriodeTpCroche
    GUILayout.BeginHorizontal();
    float setPeriodeTpCroche = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodetpcroche);
    float newSetperiodetpcroche = EditorGUILayout.Slider("setPeriodeTpCroche", setPeriodeTpCroche, 0.0f, 5000.0f);
    if (setPeriodeTpCroche != newSetperiodetpcroche) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setperiodetpcroche, newSetperiodetpcroche);
    }
    GUILayout.EndHorizontal();

    // setStaticPeriode
    GUILayout.BeginHorizontal();
    float setStaticPeriode = _dsp.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Setstaticperiode);
    float newSetstaticperiode = EditorGUILayout.Slider("setStaticPeriode", setStaticPeriode, 1.0f, 5000.0f);
    if (setStaticPeriode != newSetstaticperiode) {
      _dsp.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setstaticperiode, newSetstaticperiode);
    }
    GUILayout.EndHorizontal();

    EditorGUI.indentLevel--;

    

    GUILayout.EndVertical();
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_metronome_AudioLib : MonoBehaviour {
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_metronome_AudioLib script = GetComponent<Hv_metronome_AudioLib>();
        // Get and set a parameter
        float metroIO = script.GetFloatParameter(Hv_metronome_AudioLib.Parameter.Metroio);
        script.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Metroio, metroIO + 0.1f);
    }
  */
  public enum Parameter : uint {
    Metroio = 0x84BDBF58,
    Metroreset = 0x7995C73C,
    Resetbymesure = 0x3238E0C0,
    Setbpm = 0xEFA85BC4,
    Setperiodeblanche = 0x48B818B5,
    Setperiodecroche = 0x849DAFE8,
    Setperiodedbcroche = 0x12F25D0A,
    Setperiodemesure = 0x3E66A5DB,
    Setperiodenoire = 0xD59B74A7,
    Setperiodeqdcroche = 0xC27EEED3,
    Setperiodetpcroche = 0x467CE0B,
    Setstaticperiode = 0x3837370D,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_metronome_AudioLib script = GetComponent<Hv_metronome_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_metronome_AudioLib.FloatMessage message) {
        Debug.Log(message.receiverName + ": " + message.value);
    }
  */
  public class FloatMessage {
    public string receiverName;
    public float value;

    public FloatMessage(string name, float x) {
      receiverName = name;
      value = x;
    }
  }
  public delegate void FloatMessageReceived(FloatMessage message);
  public FloatMessageReceived FloatReceivedCallback;
  public float metroIO = 1.0f;
  public float metroReset = 1.0f;
  public float resetByMesure = 4.0f;
  public float setBpm = 75.0f;
  public float setPeriodeBlanche = 8.0f;
  public float setPeriodeCroche = 32.0f;
  public float setPeriodeDbCroche = 64.0f;
  public float setPeriodeMesure = 4.0f;
  public float setPeriodeNoire = 16.0f;
  public float setPeriodeQdCroche = 256.0f;
  public float setPeriodeTpCroche = 128.0f;
  public float setStaticPeriode = 1.0f;

  // internal state
  private Hv_metronome_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_metronome_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_metronome_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Metroio: return metroIO;
      case Parameter.Metroreset: return metroReset;
      case Parameter.Resetbymesure: return resetByMesure;
      case Parameter.Setbpm: return setBpm;
      case Parameter.Setperiodeblanche: return setPeriodeBlanche;
      case Parameter.Setperiodecroche: return setPeriodeCroche;
      case Parameter.Setperiodedbcroche: return setPeriodeDbCroche;
      case Parameter.Setperiodemesure: return setPeriodeMesure;
      case Parameter.Setperiodenoire: return setPeriodeNoire;
      case Parameter.Setperiodeqdcroche: return setPeriodeQdCroche;
      case Parameter.Setperiodetpcroche: return setPeriodeTpCroche;
      case Parameter.Setstaticperiode: return setStaticPeriode;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_metronome_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Metroio: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        metroIO = x;
        break;
      }
      case Parameter.Metroreset: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        metroReset = x;
        break;
      }
      case Parameter.Resetbymesure: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        resetByMesure = x;
        break;
      }
      case Parameter.Setbpm: {
        x = Mathf.Clamp(x, 0.0f, 300.0f);
        setBpm = x;
        break;
      }
      case Parameter.Setperiodeblanche: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeBlanche = x;
        break;
      }
      case Parameter.Setperiodecroche: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeCroche = x;
        break;
      }
      case Parameter.Setperiodedbcroche: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeDbCroche = x;
        break;
      }
      case Parameter.Setperiodemesure: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeMesure = x;
        break;
      }
      case Parameter.Setperiodenoire: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeNoire = x;
        break;
      }
      case Parameter.Setperiodeqdcroche: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeQdCroche = x;
        break;
      }
      case Parameter.Setperiodetpcroche: {
        x = Mathf.Clamp(x, 0.0f, 5000.0f);
        setPeriodeTpCroche = x;
        break;
      }
      case Parameter.Setstaticperiode: {
        x = Mathf.Clamp(x, 1.0f, 5000.0f);
        setStaticPeriode = x;
        break;
      }
      default: return;
    }
    if (IsInstantiated()) _context.SendFloatToReceiver((uint) param, x);
  }
  
  public void SendFloatToReceiver(string receiverName, float x) {
    _context.SendFloatToReceiver(StringToHash(receiverName), x);
  }

  public void FillTableWithMonoAudioClip(string tableName, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_metronome_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithMonoAudioClip(uint tableHash, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_metronome_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableHash + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(tableHash, buffer);
  }

  public void FillTableWithFloatBuffer(string tableName, float[] buffer) {
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithFloatBuffer(uint tableHash, float[] buffer) {
    _context.FillTableWithFloatBuffer(tableHash, buffer);
  }

  public uint StringToHash(string str) {
    return _context.StringToHash(str);
  }

  private void Awake() {
    _context = new Hv_metronome_Context((double) AudioSettings.outputSampleRate);
    
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Metroio, metroIO);
    _context.SendFloatToReceiver((uint) Parameter.Metroreset, metroReset);
    _context.SendFloatToReceiver((uint) Parameter.Resetbymesure, resetByMesure);
    _context.SendFloatToReceiver((uint) Parameter.Setbpm, setBpm);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodeblanche, setPeriodeBlanche);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodecroche, setPeriodeCroche);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodedbcroche, setPeriodeDbCroche);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodemesure, setPeriodeMesure);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodenoire, setPeriodeNoire);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodeqdcroche, setPeriodeQdCroche);
    _context.SendFloatToReceiver((uint) Parameter.Setperiodetpcroche, setPeriodeTpCroche);
    _context.SendFloatToReceiver((uint) Parameter.Setstaticperiode, setStaticPeriode);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_metronome_AudioLib.FloatMessage tempMessage;
      while ((tempMessage = _context.msgQueue.GetNextMessage()) != null) {
        FloatReceivedCallback(tempMessage);
      }
    }
  }

  private void OnAudioFilterRead(float[] buffer, int numChannels) {
    Assert.AreEqual(numChannels, _context.GetNumOutputChannels()); // invalid channel configuration
    _context.Process(buffer, buffer.Length / numChannels); // process dsp
  }
}

class Hv_metronome_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_metronome_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_metronome_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_metronome_AudioLib.FloatMessage>();

    public Hv_metronome_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_metronome_AudioLib.FloatMessage msg = new Hv_metronome_AudioLib.FloatMessage(receiverName, value);
      lock (_msgQueueSync) {
        _msgQueue.Enqueue(msg);
      }
    }
  }

  public readonly SendMessageQueue msgQueue = new SendMessageQueue();
  private readonly GCHandle gch;
  private readonly IntPtr _context; // handle into unmanaged memory
  private SendHook _sendHook = null;

  [DllImport (_dllName)]
  private static extern IntPtr hv_metronome_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

  [DllImport (_dllName)]
  private static extern int hv_processInlineInterleaved(IntPtr ctx,
      [In] float[] inBuffer, [Out] float[] outBuffer, int numSamples);

  [DllImport (_dllName)]
  private static extern void hv_delete(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern double hv_getSampleRate(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern int hv_getNumInputChannels(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern int hv_getNumOutputChannels(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern void hv_setSendHook(IntPtr ctx, SendHook sendHook);

  [DllImport (_dllName)]
  private static extern void hv_setPrintHook(IntPtr ctx, PrintHook printHook);

  [DllImport (_dllName)]
  private static extern int hv_setUserData(IntPtr ctx, IntPtr userData);

  [DllImport (_dllName)]
  private static extern IntPtr hv_getUserData(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern void hv_sendBangToReceiver(IntPtr ctx, uint receiverHash);

  [DllImport (_dllName)]
  private static extern void hv_sendFloatToReceiver(IntPtr ctx, uint receiverHash, float x);

  [DllImport (_dllName)]
  private static extern uint hv_msg_getTimestamp(IntPtr message);

  [DllImport (_dllName)]
  private static extern bool hv_msg_hasFormat(IntPtr message, string format);

  [DllImport (_dllName)]
  private static extern float hv_msg_getFloat(IntPtr message, int index);

  [DllImport (_dllName)]
  private static extern bool hv_table_setLength(IntPtr ctx, uint tableHash, uint newSampleLength);

  [DllImport (_dllName)]
  private static extern IntPtr hv_table_getBuffer(IntPtr ctx, uint tableHash);

  [DllImport (_dllName)]
  private static extern float hv_samplesToMilliseconds(IntPtr ctx, uint numSamples);

  [DllImport (_dllName)]
  private static extern uint hv_stringToHash(string s);

  private delegate void PrintHook(IntPtr context, string printName, string str, IntPtr message);

  private delegate void SendHook(IntPtr context, string sendName, uint sendHash, IntPtr message);

  public Hv_metronome_Context(double sampleRate, int poolKb=10, int inQueueKb=12, int outQueueKb=16) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_metronome_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_metronome_Context() {
    hv_delete(_context);
    GC.KeepAlive(_context);
    GC.KeepAlive(_sendHook);
    gch.Free();
  }

  public void RegisterSendHook() {
    // Note: send hook functionality only applies to messages containing a single float value
    if (_sendHook == null) {
      _sendHook = new SendHook(OnMessageSent);
      hv_setSendHook(_context, _sendHook);
    }
  }

  public bool IsSendHookRegistered() {
    return (_sendHook != null);
  }

  public double GetSampleRate() {
    return hv_getSampleRate(_context);
  }

  public int GetNumInputChannels() {
    return hv_getNumInputChannels(_context);
  }

  public int GetNumOutputChannels() {
    return hv_getNumOutputChannels(_context);
  }

  public void SendBangToReceiver(uint receiverHash) {
    hv_sendBangToReceiver(_context, receiverHash);
  }

  public void SendFloatToReceiver(uint receiverHash, float x) {
    hv_sendFloatToReceiver(_context, receiverHash, x);
  }

  public void FillTableWithFloatBuffer(uint tableHash, float[] buffer) {
    if (hv_table_getBuffer(_context, tableHash) != IntPtr.Zero) {
      hv_table_setLength(_context, tableHash, (uint) buffer.Length);
      Marshal.Copy(buffer, 0, hv_table_getBuffer(_context, tableHash), buffer.Length);
    } else {
      Debug.Log(string.Format("Table '{0}' doesn't exist in the patch context.", tableHash));
    }
  }

  public uint StringToHash(string s) {
    return hv_stringToHash(s);
  }

  public int Process(float[] buffer, int numFrames) {
    return hv_processInlineInterleaved(_context, buffer, buffer, numFrames);
  }

  [MonoPInvokeCallback(typeof(PrintHook))]
  private static void OnPrint(IntPtr context, string printName, string str, IntPtr message) {
    float timeInSecs = hv_samplesToMilliseconds(context, hv_msg_getTimestamp(message)) / 1000.0f;
    Debug.Log(string.Format("{0} [{1:0.000}]: {2}", printName, timeInSecs, str));
  }

  [MonoPInvokeCallback(typeof(SendHook))]
  private static void OnMessageSent(IntPtr context, string sendName, uint sendHash, IntPtr message) {
    if (hv_msg_hasFormat(message, "f")) {
      SendMessageQueue msgQueue = (SendMessageQueue) GCHandle.FromIntPtr(hv_getUserData(context)).Target;
      msgQueue.AddMessage(sendName, hv_msg_getFloat(message, 0));
    }
  }
}
