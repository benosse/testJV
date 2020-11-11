<<<<<<< HEAD
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

[CustomEditor(typeof(Hv_adsr_AudioLib))]
public class Hv_adsr_Editor : Editor {

  [MenuItem("Heavy/adsr")]
  static void CreateHv_adsr() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_adsr_AudioLib>();
    }
  }

  private Hv_adsr_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_adsr_AudioLib;
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

    // attackTimeAdsr
    GUILayout.BeginHorizontal();
    float attackTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr);
    float newAttacktimeadsr = EditorGUILayout.Slider("attackTimeAdsr", attackTimeAdsr, 0.0f, 48000.0f);
    if (attackTimeAdsr != newAttacktimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, newAttacktimeadsr);
    }
    GUILayout.EndHorizontal();

    // decayTimeAdsr
    GUILayout.BeginHorizontal();
    float decayTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr);
    float newDecaytimeadsr = EditorGUILayout.Slider("decayTimeAdsr", decayTimeAdsr, 0.0f, 48000.0f);
    if (decayTimeAdsr != newDecaytimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, newDecaytimeadsr);
    }
    GUILayout.EndHorizontal();

    // formeAttackAdsr
    GUILayout.BeginHorizontal();
    float formeAttackAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr);
    float newFormeattackadsr = EditorGUILayout.Slider("formeAttackAdsr", formeAttackAdsr, 0.0f, 3.0f);
    if (formeAttackAdsr != newFormeattackadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr, newFormeattackadsr);
    }
    GUILayout.EndHorizontal();

    // formeDecayAdsr
    GUILayout.BeginHorizontal();
    float formeDecayAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr);
    float newFormedecayadsr = EditorGUILayout.Slider("formeDecayAdsr", formeDecayAdsr, 0.0f, 3.0f);
    if (formeDecayAdsr != newFormedecayadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr, newFormedecayadsr);
    }
    GUILayout.EndHorizontal();

    // formeReleaseAdsr
    GUILayout.BeginHorizontal();
    float formeReleaseAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr);
    float newFormereleaseadsr = EditorGUILayout.Slider("formeReleaseAdsr", formeReleaseAdsr, 0.0f, 3.0f);
    if (formeReleaseAdsr != newFormereleaseadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr, newFormereleaseadsr);
    }
    GUILayout.EndHorizontal();

    // modeResetAdsr
    GUILayout.BeginHorizontal();
    float modeResetAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr);
    float newModeresetadsr = EditorGUILayout.Slider("modeResetAdsr", modeResetAdsr, 0.0f, 1.0f);
    if (modeResetAdsr != newModeresetadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr, newModeresetadsr);
    }
    GUILayout.EndHorizontal();

    // releaseTimeAdsr
    GUILayout.BeginHorizontal();
    float releaseTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr);
    float newReleasetimeadsr = EditorGUILayout.Slider("releaseTimeAdsr", releaseTimeAdsr, 0.0f, 48000.0f);
    if (releaseTimeAdsr != newReleasetimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, newReleasetimeadsr);
    }
    GUILayout.EndHorizontal();

    // seuilAdsr
    GUILayout.BeginHorizontal();
    float seuilAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Seuiladsr);
    float newSeuiladsr = EditorGUILayout.Slider("seuilAdsr", seuilAdsr, 0.0f, 1.0f);
    if (seuilAdsr != newSeuiladsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Seuiladsr, newSeuiladsr);
    }
    GUILayout.EndHorizontal();

    // smoothEnvAdsr
    GUILayout.BeginHorizontal();
    float smoothEnvAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothenvadsr);
    float newSmoothenvadsr = EditorGUILayout.Slider("smoothEnvAdsr", smoothEnvAdsr, 10.0f, 2000.0f);
    if (smoothEnvAdsr != newSmoothenvadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothenvadsr, newSmoothenvadsr);
    }
    GUILayout.EndHorizontal();

    // smoothReset
    GUILayout.BeginHorizontal();
    float smoothReset = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothreset);
    float newSmoothreset = EditorGUILayout.Slider("smoothReset", smoothReset, 0.0f, 1.0f);
    if (smoothReset != newSmoothreset) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothreset, newSmoothreset);
    }
    GUILayout.EndHorizontal();

    // sustainTimeAdsr
    GUILayout.BeginHorizontal();
    float sustainTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr);
    float newSustaintimeadsr = EditorGUILayout.Slider("sustainTimeAdsr", sustainTimeAdsr, 0.0f, 48000.0f);
    if (sustainTimeAdsr != newSustaintimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, newSustaintimeadsr);
    }
    GUILayout.EndHorizontal();

    // triggerAdsr
    GUILayout.BeginHorizontal();
    float triggerAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr);
    float newTriggeradsr = EditorGUILayout.Slider("triggerAdsr", triggerAdsr, 0.0f, 1.0f);
    if (triggerAdsr != newTriggeradsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, newTriggeradsr);
    }
    GUILayout.EndHorizontal();

    EditorGUI.indentLevel--;

    

    GUILayout.EndVertical();
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_adsr_AudioLib : MonoBehaviour {
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_adsr_AudioLib script = GetComponent<Hv_adsr_AudioLib>();
        // Get and set a parameter
        float attackTimeAdsr = script.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr);
        script.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, attackTimeAdsr + 0.1f);
    }
  */
  public enum Parameter : uint {
    Attacktimeadsr = 0x5D1DF69B,
    Decaytimeadsr = 0x51996824,
    Formeattackadsr = 0xD188097B,
    Formedecayadsr = 0x926A1E85,
    Formereleaseadsr = 0x46E3FF4C,
    Moderesetadsr = 0xAE15F8F1,
    Releasetimeadsr = 0x5BDFCB23,
    Seuiladsr = 0x30B93C36,
    Smoothenvadsr = 0xC6514CC9,
    Smoothreset = 0x3927FBE6,
    Sustaintimeadsr = 0xA0FC7AD,
    Triggeradsr = 0x3C23D823,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_adsr_AudioLib script = GetComponent<Hv_adsr_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_adsr_AudioLib.FloatMessage message) {
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
  public float attackTimeAdsr = 1600.0f;
  public float decayTimeAdsr = 3200.0f;
  public float formeAttackAdsr = 0.0f;
  public float formeDecayAdsr = 0.0f;
  public float formeReleaseAdsr = 0.0f;
  public float modeResetAdsr = 1.0f;
  public float releaseTimeAdsr = 1600.0f;
  public float seuilAdsr = 0.5f;
  public float smoothEnvAdsr = 20.0f;
  public float smoothReset = 0.0f;
  public float sustainTimeAdsr = 1600.0f;
  public float triggerAdsr = 0.0f;

  // internal state
  private Hv_adsr_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_adsr_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_adsr_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Attacktimeadsr: return attackTimeAdsr;
      case Parameter.Decaytimeadsr: return decayTimeAdsr;
      case Parameter.Formeattackadsr: return formeAttackAdsr;
      case Parameter.Formedecayadsr: return formeDecayAdsr;
      case Parameter.Formereleaseadsr: return formeReleaseAdsr;
      case Parameter.Moderesetadsr: return modeResetAdsr;
      case Parameter.Releasetimeadsr: return releaseTimeAdsr;
      case Parameter.Seuiladsr: return seuilAdsr;
      case Parameter.Smoothenvadsr: return smoothEnvAdsr;
      case Parameter.Smoothreset: return smoothReset;
      case Parameter.Sustaintimeadsr: return sustainTimeAdsr;
      case Parameter.Triggeradsr: return triggerAdsr;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_adsr_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Attacktimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        attackTimeAdsr = x;
        break;
      }
      case Parameter.Decaytimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        decayTimeAdsr = x;
        break;
      }
      case Parameter.Formeattackadsr: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeAttackAdsr = x;
        break;
      }
      case Parameter.Formedecayadsr: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeDecayAdsr = x;
        break;
      }
      case Parameter.Formereleaseadsr: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeReleaseAdsr = x;
        break;
      }
      case Parameter.Moderesetadsr: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        modeResetAdsr = x;
        break;
      }
      case Parameter.Releasetimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        releaseTimeAdsr = x;
        break;
      }
      case Parameter.Seuiladsr: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        seuilAdsr = x;
        break;
      }
      case Parameter.Smoothenvadsr: {
        x = Mathf.Clamp(x, 10.0f, 2000.0f);
        smoothEnvAdsr = x;
        break;
      }
      case Parameter.Smoothreset: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        smoothReset = x;
        break;
      }
      case Parameter.Sustaintimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        sustainTimeAdsr = x;
        break;
      }
      case Parameter.Triggeradsr: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        triggerAdsr = x;
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
      Debug.LogWarning("Hv_adsr_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithMonoAudioClip(uint tableHash, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_adsr_AudioLib: Only loading first channel of '" +
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
    _context = new Hv_adsr_Context((double) AudioSettings.outputSampleRate);
    
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Attacktimeadsr, attackTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Decaytimeadsr, decayTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Formeattackadsr, formeAttackAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Formedecayadsr, formeDecayAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Formereleaseadsr, formeReleaseAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Moderesetadsr, modeResetAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Releasetimeadsr, releaseTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Seuiladsr, seuilAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Smoothenvadsr, smoothEnvAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Smoothreset, smoothReset);
    _context.SendFloatToReceiver((uint) Parameter.Sustaintimeadsr, sustainTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Triggeradsr, triggerAdsr);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_adsr_AudioLib.FloatMessage tempMessage;
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

class Hv_adsr_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_adsr_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_adsr_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_adsr_AudioLib.FloatMessage>();

    public Hv_adsr_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_adsr_AudioLib.FloatMessage msg = new Hv_adsr_AudioLib.FloatMessage(receiverName, value);
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
  private static extern IntPtr hv_adsr_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

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

  public Hv_adsr_Context(double sampleRate, int poolKb=10, int inQueueKb=12, int outQueueKb=3) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_adsr_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_adsr_Context() {
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
=======
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

[CustomEditor(typeof(Hv_adsr_AudioLib))]
public class Hv_adsr_Editor : Editor {

  [MenuItem("Heavy/adsr")]
  static void CreateHv_adsr() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_adsr_AudioLib>();
    }
  }

  private Hv_adsr_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_adsr_AudioLib;
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

    // attackTimeAdsr
    GUILayout.BeginHorizontal();
    float attackTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr);
    float newAttacktimeadsr = EditorGUILayout.Slider("attackTimeAdsr", attackTimeAdsr, 0.0f, 48000.0f);
    if (attackTimeAdsr != newAttacktimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, newAttacktimeadsr);
    }
    GUILayout.EndHorizontal();

    // decayTimeAdsr
    GUILayout.BeginHorizontal();
    float decayTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr);
    float newDecaytimeadsr = EditorGUILayout.Slider("decayTimeAdsr", decayTimeAdsr, 0.0f, 48000.0f);
    if (decayTimeAdsr != newDecaytimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, newDecaytimeadsr);
    }
    GUILayout.EndHorizontal();

    // formeAttackAdsr
    GUILayout.BeginHorizontal();
    float formeAttackAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr);
    float newFormeattackadsr = EditorGUILayout.Slider("formeAttackAdsr", formeAttackAdsr, 0.0f, 3.0f);
    if (formeAttackAdsr != newFormeattackadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr, newFormeattackadsr);
    }
    GUILayout.EndHorizontal();

    // formeDecayAdsr
    GUILayout.BeginHorizontal();
    float formeDecayAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr);
    float newFormedecayadsr = EditorGUILayout.Slider("formeDecayAdsr", formeDecayAdsr, 0.0f, 3.0f);
    if (formeDecayAdsr != newFormedecayadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr, newFormedecayadsr);
    }
    GUILayout.EndHorizontal();

    // formeReleaseAdsr
    GUILayout.BeginHorizontal();
    float formeReleaseAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr);
    float newFormereleaseadsr = EditorGUILayout.Slider("formeReleaseAdsr", formeReleaseAdsr, 0.0f, 3.0f);
    if (formeReleaseAdsr != newFormereleaseadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr, newFormereleaseadsr);
    }
    GUILayout.EndHorizontal();

    // modeResetAdsr
    GUILayout.BeginHorizontal();
    float modeResetAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr);
    float newModeresetadsr = EditorGUILayout.Slider("modeResetAdsr", modeResetAdsr, 0.0f, 1.0f);
    if (modeResetAdsr != newModeresetadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr, newModeresetadsr);
    }
    GUILayout.EndHorizontal();

    // releaseTimeAdsr
    GUILayout.BeginHorizontal();
    float releaseTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr);
    float newReleasetimeadsr = EditorGUILayout.Slider("releaseTimeAdsr", releaseTimeAdsr, 0.0f, 48000.0f);
    if (releaseTimeAdsr != newReleasetimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, newReleasetimeadsr);
    }
    GUILayout.EndHorizontal();

    // seuilAdsr
    GUILayout.BeginHorizontal();
    float seuilAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Seuiladsr);
    float newSeuiladsr = EditorGUILayout.Slider("seuilAdsr", seuilAdsr, 0.0f, 1.0f);
    if (seuilAdsr != newSeuiladsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Seuiladsr, newSeuiladsr);
    }
    GUILayout.EndHorizontal();

    // sustainTimeAdsr
    GUILayout.BeginHorizontal();
    float sustainTimeAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr);
    float newSustaintimeadsr = EditorGUILayout.Slider("sustainTimeAdsr", sustainTimeAdsr, 0.0f, 48000.0f);
    if (sustainTimeAdsr != newSustaintimeadsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, newSustaintimeadsr);
    }
    GUILayout.EndHorizontal();

    // triggerAdsr
    GUILayout.BeginHorizontal();
    float triggerAdsr = _dsp.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr);
    float newTriggeradsr = EditorGUILayout.Slider("triggerAdsr", triggerAdsr, 0.0f, 1.0f);
    if (triggerAdsr != newTriggeradsr) {
      _dsp.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, newTriggeradsr);
    }
    GUILayout.EndHorizontal();

    EditorGUI.indentLevel--;

    

    GUILayout.EndVertical();
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_adsr_AudioLib : MonoBehaviour {
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_adsr_AudioLib script = GetComponent<Hv_adsr_AudioLib>();
        // Get and set a parameter
        float attackTimeAdsr = script.GetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr);
        script.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, attackTimeAdsr + 0.1f);
    }
  */
  public enum Parameter : uint {
    Attacktimeadsr = 0x5D1DF69B,
    Decaytimeadsr = 0x51996824,
    Formeattackadsr = 0xD188097B,
    Formedecayadsr = 0x926A1E85,
    Formereleaseadsr = 0x46E3FF4C,
    Moderesetadsr = 0xAE15F8F1,
    Releasetimeadsr = 0x5BDFCB23,
    Seuiladsr = 0x30B93C36,
    Sustaintimeadsr = 0xA0FC7AD,
    Triggeradsr = 0x3C23D823,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_adsr_AudioLib script = GetComponent<Hv_adsr_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_adsr_AudioLib.FloatMessage message) {
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
  public float attackTimeAdsr = 1600.0f;
  public float decayTimeAdsr = 3200.0f;
  public float formeAttackAdsr = 0.0f;
  public float formeDecayAdsr = 0.0f;
  public float formeReleaseAdsr = 0.0f;
  public float modeResetAdsr = 1.0f;
  public float releaseTimeAdsr = 1600.0f;
  public float seuilAdsr = 0.5f;
  public float sustainTimeAdsr = 1600.0f;
  public float triggerAdsr = 0.0f;

  // internal state
  private Hv_adsr_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_adsr_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_adsr_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Attacktimeadsr: return attackTimeAdsr;
      case Parameter.Decaytimeadsr: return decayTimeAdsr;
      case Parameter.Formeattackadsr: return formeAttackAdsr;
      case Parameter.Formedecayadsr: return formeDecayAdsr;
      case Parameter.Formereleaseadsr: return formeReleaseAdsr;
      case Parameter.Moderesetadsr: return modeResetAdsr;
      case Parameter.Releasetimeadsr: return releaseTimeAdsr;
      case Parameter.Seuiladsr: return seuilAdsr;
      case Parameter.Sustaintimeadsr: return sustainTimeAdsr;
      case Parameter.Triggeradsr: return triggerAdsr;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_adsr_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Attacktimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        attackTimeAdsr = x;
        break;
      }
      case Parameter.Decaytimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        decayTimeAdsr = x;
        break;
      }
      case Parameter.Formeattackadsr: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeAttackAdsr = x;
        break;
      }
      case Parameter.Formedecayadsr: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeDecayAdsr = x;
        break;
      }
      case Parameter.Formereleaseadsr: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        formeReleaseAdsr = x;
        break;
      }
      case Parameter.Moderesetadsr: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        modeResetAdsr = x;
        break;
      }
      case Parameter.Releasetimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        releaseTimeAdsr = x;
        break;
      }
      case Parameter.Seuiladsr: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        seuilAdsr = x;
        break;
      }
      case Parameter.Sustaintimeadsr: {
        x = Mathf.Clamp(x, 0.0f, 48000.0f);
        sustainTimeAdsr = x;
        break;
      }
      case Parameter.Triggeradsr: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        triggerAdsr = x;
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
      Debug.LogWarning("Hv_adsr_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithMonoAudioClip(uint tableHash, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_adsr_AudioLib: Only loading first channel of '" +
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
    _context = new Hv_adsr_Context((double) AudioSettings.outputSampleRate);
    
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Attacktimeadsr, attackTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Decaytimeadsr, decayTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Formeattackadsr, formeAttackAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Formedecayadsr, formeDecayAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Formereleaseadsr, formeReleaseAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Moderesetadsr, modeResetAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Releasetimeadsr, releaseTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Seuiladsr, seuilAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Sustaintimeadsr, sustainTimeAdsr);
    _context.SendFloatToReceiver((uint) Parameter.Triggeradsr, triggerAdsr);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_adsr_AudioLib.FloatMessage tempMessage;
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

class Hv_adsr_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_adsr_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_adsr_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_adsr_AudioLib.FloatMessage>();

    public Hv_adsr_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_adsr_AudioLib.FloatMessage msg = new Hv_adsr_AudioLib.FloatMessage(receiverName, value);
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
  private static extern IntPtr hv_adsr_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

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

  public Hv_adsr_Context(double sampleRate, int poolKb=10, int inQueueKb=10, int outQueueKb=4) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_adsr_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_adsr_Context() {
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
>>>>>>> XRrig
