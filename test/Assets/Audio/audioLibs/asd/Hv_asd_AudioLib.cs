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

[CustomEditor(typeof(Hv_asd_AudioLib))]
public class Hv_asd_Editor : Editor {

  [MenuItem("Heavy/asd")]
  static void CreateHv_asd() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_asd_AudioLib>();
    }
  }

  private Hv_asd_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_asd_AudioLib;
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

    // attackTimeAsd
    GUILayout.BeginHorizontal();
    float attackTimeAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Attacktimeasd);
    float newAttacktimeasd = EditorGUILayout.Slider("attackTimeAsd", attackTimeAsd, 0.0f, 48000.0f);
    if (attackTimeAsd != newAttacktimeasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Attacktimeasd, newAttacktimeasd);
    }
    GUILayout.EndHorizontal();

    // decayTimeAsd
    GUILayout.BeginHorizontal();
    float decayTimeAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Decaytimeasd);
    float newDecaytimeasd = EditorGUILayout.Slider("decayTimeAsd", decayTimeAsd, 0.0f, 48000.0f);
    if (decayTimeAsd != newDecaytimeasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Decaytimeasd, newDecaytimeasd);
    }
    GUILayout.EndHorizontal();

    // formeAttackAsd
    GUILayout.BeginHorizontal();
    float formeAttackAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Formeattackasd);
    float newFormeattackasd = EditorGUILayout.Slider("formeAttackAsd", formeAttackAsd, 0.0f, 3.0f);
    if (formeAttackAsd != newFormeattackasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Formeattackasd, newFormeattackasd);
    }
    GUILayout.EndHorizontal();

    // formeDecayAsd
    GUILayout.BeginHorizontal();
    float formeDecayAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Formedecayasd);
    float newFormedecayasd = EditorGUILayout.Slider("formeDecayAsd", formeDecayAsd, 0.0f, 3.0f);
    if (formeDecayAsd != newFormedecayasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Formedecayasd, newFormedecayasd);
    }
    GUILayout.EndHorizontal();

    // modeResetAsd
    GUILayout.BeginHorizontal();
    float modeResetAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Moderesetasd);
    float newModeresetasd = EditorGUILayout.Slider("modeResetAsd", modeResetAsd, 0.0f, 1.0f);
    if (modeResetAsd != newModeresetasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Moderesetasd, newModeresetasd);
    }
    GUILayout.EndHorizontal();

    // sustainTimeAsd
    GUILayout.BeginHorizontal();
    float sustainTimeAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Sustaintimeasd);
    float newSustaintimeasd = EditorGUILayout.Slider("sustainTimeAsd", sustainTimeAsd, 0.0f, 48000.0f);
    if (sustainTimeAsd != newSustaintimeasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Sustaintimeasd, newSustaintimeasd);
    }
    GUILayout.EndHorizontal();

    // triggerAsd
    GUILayout.BeginHorizontal();
    float triggerAsd = _dsp.GetFloatParameter(Hv_asd_AudioLib.Parameter.Triggerasd);
    float newTriggerasd = EditorGUILayout.Slider("triggerAsd", triggerAsd, 0.0f, 1.0f);
    if (triggerAsd != newTriggerasd) {
      _dsp.SetFloatParameter(Hv_asd_AudioLib.Parameter.Triggerasd, newTriggerasd);
    }
    GUILayout.EndHorizontal();

    EditorGUI.indentLevel--;

    

    GUILayout.EndVertical();
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_asd_AudioLib : MonoBehaviour {
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_asd_AudioLib script = GetComponent<Hv_asd_AudioLib>();
        // Get and set a parameter
        float attackTimeAsd = script.GetFloatParameter(Hv_asd_AudioLib.Parameter.Attacktimeasd);
        script.SetFloatParameter(Hv_asd_AudioLib.Parameter.Attacktimeasd, attackTimeAsd + 0.1f);
    }
  */
  public enum Parameter : uint {
    Attacktimeasd = 0x1F1DA50A,
    Decaytimeasd = 0x8A394F6,
    Formeattackasd = 0x2FBAEF19,
    Formedecayasd = 0xB58815C9,
    Moderesetasd = 0x204EE879,
    Sustaintimeasd = 0x5C28DCC5,
    Triggerasd = 0xA47D1979,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_asd_AudioLib script = GetComponent<Hv_asd_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_asd_AudioLib.FloatMessage message) {
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
  public float attackTimeAsd = 1600.0f;
  public float decayTimeAsd = 3200.0f;
  public float formeAttackAsd = 0.0f;
  public float formeDecayAsd = 0.0f;
  public float modeResetAsd = 1.0f;
  public float sustainTimeAsd = 1600.0f;
  public float triggerAsd = 0.0f;

  // internal state
  private Hv_asd_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_asd_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_asd_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Attacktimeasd: return attackTimeAsd;
      case Parameter.Decaytimeasd: return decayTimeAsd;
      case Parameter.Formeattackasd: return formeAttackAsd;
      case Parameter.Formedecayasd: return formeDecayAsd;
      case Parameter.Moderesetasd: return modeResetAsd;
      case Parameter.Sustaintimeasd: return sustainTimeAsd;
      case Parameter.Triggerasd: return triggerAsd;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_asd_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Attacktimeasd: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        attackTimeAsd = x;
        break;
      }
      case Parameter.Decaytimeasd: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        decayTimeAsd = x;
        break;
      }
      case Parameter.Formeattackasd: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeAttackAsd = x;
        break;
      }
      case Parameter.Formedecayasd: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeDecayAsd = x;
        break;
      }
      case Parameter.Moderesetasd: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        modeResetAsd = x;
        break;
      }
      case Parameter.Sustaintimeasd: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        sustainTimeAsd = x;
        break;
      }
      case Parameter.Triggerasd: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        triggerAsd = x;
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
      Debug.LogWarning("Hv_asd_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithMonoAudioClip(uint tableHash, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_asd_AudioLib: Only loading first channel of '" +
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
    _context = new Hv_asd_Context((double) AudioSettings.outputSampleRate);
    
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Attacktimeasd, attackTimeAsd);
    _context.SendFloatToReceiver((uint) Parameter.Decaytimeasd, decayTimeAsd);
    _context.SendFloatToReceiver((uint) Parameter.Formeattackasd, formeAttackAsd);
    _context.SendFloatToReceiver((uint) Parameter.Formedecayasd, formeDecayAsd);
    _context.SendFloatToReceiver((uint) Parameter.Moderesetasd, modeResetAsd);
    _context.SendFloatToReceiver((uint) Parameter.Sustaintimeasd, sustainTimeAsd);
    _context.SendFloatToReceiver((uint) Parameter.Triggerasd, triggerAsd);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_asd_AudioLib.FloatMessage tempMessage;
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

class Hv_asd_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_asd_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_asd_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_asd_AudioLib.FloatMessage>();

    public Hv_asd_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_asd_AudioLib.FloatMessage msg = new Hv_asd_AudioLib.FloatMessage(receiverName, value);
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
  private static extern IntPtr hv_asd_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

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

  public Hv_asd_Context(double sampleRate, int poolKb=10, int inQueueKb=7, int outQueueKb=2) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_asd_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_asd_Context() {
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
