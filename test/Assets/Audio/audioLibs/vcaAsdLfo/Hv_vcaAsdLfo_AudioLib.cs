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

[CustomEditor(typeof(Hv_vcaAsdLfo_AudioLib))]
public class Hv_vcaAsdLfo_Editor : Editor {

  [MenuItem("Heavy/vcaAsdLfo")]
  static void CreateHv_vcaAsdLfo() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_vcaAsdLfo_AudioLib>();
    }
  }

  private Hv_vcaAsdLfo_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_vcaAsdLfo_AudioLib;
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

    // asdAttackTime
    GUILayout.BeginHorizontal();
    float asdAttackTime = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asdattacktime);
    float newAsdattacktime = EditorGUILayout.Slider("asdAttackTime", asdAttackTime, 0.0f, 12000.0f);
    if (asdAttackTime != newAsdattacktime) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asdattacktime, newAsdattacktime);
    }
    GUILayout.EndHorizontal();

    // asdDecayTime
    GUILayout.BeginHorizontal();
    float asdDecayTime = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asddecaytime);
    float newAsddecaytime = EditorGUILayout.Slider("asdDecayTime", asdDecayTime, 0.0f, 12000.0f);
    if (asdDecayTime != newAsddecaytime) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asddecaytime, newAsddecaytime);
    }
    GUILayout.EndHorizontal();

    // asdSustainTime
    GUILayout.BeginHorizontal();
    float asdSustainTime = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asdsustaintime);
    float newAsdsustaintime = EditorGUILayout.Slider("asdSustainTime", asdSustainTime, 0.0f, 12000.0f);
    if (asdSustainTime != newAsdsustaintime) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asdsustaintime, newAsdsustaintime);
    }
    GUILayout.EndHorizontal();

    // cycleTime
    GUILayout.BeginHorizontal();
    float cycleTime = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Cycletime);
    float newCycletime = EditorGUILayout.Slider("cycleTime", cycleTime, 0.0f, 24000.0f);
    if (cycleTime != newCycletime) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Cycletime, newCycletime);
    }
    GUILayout.EndHorizontal();

    // formeAttack
    GUILayout.BeginHorizontal();
    float formeAttack = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Formeattack);
    float newFormeattack = EditorGUILayout.Slider("formeAttack", formeAttack, 0.0f, 3.0f);
    if (formeAttack != newFormeattack) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Formeattack, newFormeattack);
    }
    GUILayout.EndHorizontal();

    // formeCycle
    GUILayout.BeginHorizontal();
    float formeCycle = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Formecycle);
    float newFormecycle = EditorGUILayout.Slider("formeCycle", formeCycle, 0.0f, 5.0f);
    if (formeCycle != newFormecycle) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Formecycle, newFormecycle);
    }
    GUILayout.EndHorizontal();

    // formeDecay
    GUILayout.BeginHorizontal();
    float formeDecay = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Formedecay);
    float newFormedecay = EditorGUILayout.Slider("formeDecay", formeDecay, 0.0f, 3.0f);
    if (formeDecay != newFormedecay) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Formedecay, newFormedecay);
    }
    GUILayout.EndHorizontal();

    // modeVca
    GUILayout.BeginHorizontal();
    float modeVca = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Modevca);
    float newModevca = EditorGUILayout.Slider("modeVca", modeVca, 0.0f, 1.0f);
    if (modeVca != newModevca) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Modevca, newModevca);
    }
    GUILayout.EndHorizontal();

    // selectInput
    GUILayout.BeginHorizontal();
    float selectInput = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Selectinput);
    float newSelectinput = EditorGUILayout.Slider("selectInput", selectInput, 0.0f, 2.0f);
    if (selectInput != newSelectinput) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Selectinput, newSelectinput);
    }
    GUILayout.EndHorizontal();

    // smoothSignal
    GUILayout.BeginHorizontal();
    float smoothSignal = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Smoothsignal);
    float newSmoothsignal = EditorGUILayout.Slider("smoothSignal", smoothSignal, 0.0f, 20.0f);
    if (smoothSignal != newSmoothsignal) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Smoothsignal, newSmoothsignal);
    }
    GUILayout.EndHorizontal();

    // trigMode
    GUILayout.BeginHorizontal();
    float trigMode = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Trigmode);
    float newTrigmode = EditorGUILayout.Slider("trigMode", trigMode, 0.0f, 1.0f);
    if (trigMode != newTrigmode) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Trigmode, newTrigmode);
    }
    GUILayout.EndHorizontal();

    // triggerIO
    GUILayout.BeginHorizontal();
    float triggerIO = _dsp.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Triggerio);
    float newTriggerio = EditorGUILayout.Slider("triggerIO", triggerIO, 0.0f, 1.0f);
    if (triggerIO != newTriggerio) {
      _dsp.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Triggerio, newTriggerio);
    }
    GUILayout.EndHorizontal();

    EditorGUI.indentLevel--;

    

    GUILayout.EndVertical();
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_vcaAsdLfo_AudioLib : MonoBehaviour {
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_vcaAsdLfo_AudioLib script = GetComponent<Hv_vcaAsdLfo_AudioLib>();
        // Get and set a parameter
        float asdAttackTime = script.GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asdattacktime);
        script.SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter.Asdattacktime, asdAttackTime + 0.1f);
    }
  */
  public enum Parameter : uint {
    Asdattacktime = 0x45836F04,
    Asddecaytime = 0x6AD9D756,
    Asdsustaintime = 0x3295AB29,
    Cycletime = 0xEE34A9D0,
    Formeattack = 0x515BE438,
    Formecycle = 0xF8CB04C4,
    Formedecay = 0x4DAC9050,
    Modevca = 0x3C1062EA,
    Selectinput = 0xE5A282B9,
    Smoothsignal = 0x41320490,
    Trigmode = 0x44E59050,
    Triggerio = 0x8DFF4563,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_vcaAsdLfo_AudioLib script = GetComponent<Hv_vcaAsdLfo_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_vcaAsdLfo_AudioLib.FloatMessage message) {
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
  public float asdAttackTime = 2800.0f;
  public float asdDecayTime = 3200.0f;
  public float asdSustainTime = 400.0f;
  public float cycleTime = 6400.0f;
  public float formeAttack = 0.0f;
  public float formeCycle = 0.0f;
  public float formeDecay = 1.0f;
  public float modeVca = 1.0f;
  public float selectInput = 2.0f;
  public float smoothSignal = 0.1f;
  public float trigMode = 0.0f;
  public float triggerIO = 0.0f;

  // internal state
  private Hv_vcaAsdLfo_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_vcaAsdLfo_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Asdattacktime: return asdAttackTime;
      case Parameter.Asddecaytime: return asdDecayTime;
      case Parameter.Asdsustaintime: return asdSustainTime;
      case Parameter.Cycletime: return cycleTime;
      case Parameter.Formeattack: return formeAttack;
      case Parameter.Formecycle: return formeCycle;
      case Parameter.Formedecay: return formeDecay;
      case Parameter.Modevca: return modeVca;
      case Parameter.Selectinput: return selectInput;
      case Parameter.Smoothsignal: return smoothSignal;
      case Parameter.Trigmode: return trigMode;
      case Parameter.Triggerio: return triggerIO;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_vcaAsdLfo_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Asdattacktime: {
        x = Mathf.Clamp(x, 0.0f, 12000.0f);
        asdAttackTime = x;
        break;
      }
      case Parameter.Asddecaytime: {
        x = Mathf.Clamp(x, 0.0f, 12000.0f);
        asdDecayTime = x;
        break;
      }
      case Parameter.Asdsustaintime: {
        x = Mathf.Clamp(x, 0.0f, 12000.0f);
        asdSustainTime = x;
        break;
      }
      case Parameter.Cycletime: {
        x = Mathf.Clamp(x, 0.0f, 24000.0f);
        cycleTime = x;
        break;
      }
      case Parameter.Formeattack: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeAttack = x;
        break;
      }
      case Parameter.Formecycle: {
        x = Mathf.Clamp(x, 0.0f, 5.0f);
        formeCycle = x;
        break;
      }
      case Parameter.Formedecay: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeDecay = x;
        break;
      }
      case Parameter.Modevca: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        modeVca = x;
        break;
      }
      case Parameter.Selectinput: {
        x = Mathf.Clamp(x, 0.0f, 2.0f);
        selectInput = x;
        break;
      }
      case Parameter.Smoothsignal: {
        x = Mathf.Clamp(x, 0.0f, 20.0f);
        smoothSignal = x;
        break;
      }
      case Parameter.Trigmode: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        trigMode = x;
        break;
      }
      case Parameter.Triggerio: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        triggerIO = x;
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
      Debug.LogWarning("Hv_vcaAsdLfo_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithMonoAudioClip(uint tableHash, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_vcaAsdLfo_AudioLib: Only loading first channel of '" +
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
    _context = new Hv_vcaAsdLfo_Context((double) AudioSettings.outputSampleRate);
    
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Asdattacktime, asdAttackTime);
    _context.SendFloatToReceiver((uint) Parameter.Asddecaytime, asdDecayTime);
    _context.SendFloatToReceiver((uint) Parameter.Asdsustaintime, asdSustainTime);
    _context.SendFloatToReceiver((uint) Parameter.Cycletime, cycleTime);
    _context.SendFloatToReceiver((uint) Parameter.Formeattack, formeAttack);
    _context.SendFloatToReceiver((uint) Parameter.Formecycle, formeCycle);
    _context.SendFloatToReceiver((uint) Parameter.Formedecay, formeDecay);
    _context.SendFloatToReceiver((uint) Parameter.Modevca, modeVca);
    _context.SendFloatToReceiver((uint) Parameter.Selectinput, selectInput);
    _context.SendFloatToReceiver((uint) Parameter.Smoothsignal, smoothSignal);
    _context.SendFloatToReceiver((uint) Parameter.Trigmode, trigMode);
    _context.SendFloatToReceiver((uint) Parameter.Triggerio, triggerIO);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_vcaAsdLfo_AudioLib.FloatMessage tempMessage;
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

class Hv_vcaAsdLfo_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_vcaAsdLfo_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_vcaAsdLfo_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_vcaAsdLfo_AudioLib.FloatMessage>();

    public Hv_vcaAsdLfo_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_vcaAsdLfo_AudioLib.FloatMessage msg = new Hv_vcaAsdLfo_AudioLib.FloatMessage(receiverName, value);
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
  private static extern IntPtr hv_vcaAsdLfo_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

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

  public Hv_vcaAsdLfo_Context(double sampleRate, int poolKb=10, int inQueueKb=12, int outQueueKb=3) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_vcaAsdLfo_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_vcaAsdLfo_Context() {
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
