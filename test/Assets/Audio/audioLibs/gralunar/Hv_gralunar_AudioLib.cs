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

[CustomEditor(typeof(Hv_gralunar_AudioLib))]
public class Hv_gralunar_Editor : Editor {

  [MenuItem("Heavy/gralunar")]
  static void CreateHv_gralunar() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_gralunar_AudioLib>();
    }
  }

  private Hv_gralunar_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_gralunar_AudioLib;
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

    // grainDur
    GUILayout.BeginHorizontal();
    float grainDur = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Graindur);
    float newGraindur = EditorGUILayout.Slider("grainDur", grainDur, 0.0f, 16000.0f);
    if (grainDur != newGraindur) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Graindur, newGraindur);
    }
    GUILayout.EndHorizontal();

    // grainPitch
    GUILayout.BeginHorizontal();
    float grainPitch = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Grainpitch);
    float newGrainpitch = EditorGUILayout.Slider("grainPitch", grainPitch, 0.0f, 16.0f);
    if (grainPitch != newGrainpitch) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Grainpitch, newGrainpitch);
    }
    GUILayout.EndHorizontal();

    // grainStart
    GUILayout.BeginHorizontal();
    float grainStart = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Grainstart);
    float newGrainstart = EditorGUILayout.Slider("grainStart", grainStart, 0.0f, 1.0f);
    if (grainStart != newGrainstart) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Grainstart, newGrainstart);
    }
    GUILayout.EndHorizontal();

    // inGainGrains
    GUILayout.BeginHorizontal();
    float inGainGrains = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Ingaingrains);
    float newIngaingrains = EditorGUILayout.Slider("inGainGrains", inGainGrains, 0.0f, 1.0f);
    if (inGainGrains != newIngaingrains) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Ingaingrains, newIngaingrains);
    }
    GUILayout.EndHorizontal();

    // inputGrains
    GUILayout.BeginHorizontal();
    float inputGrains = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Inputgrains);
    float newInputgrains = EditorGUILayout.Slider("inputGrains", inputGrains, 0.0f, 2.0f);
    if (inputGrains != newInputgrains) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Inputgrains, newInputgrains);
    }
    GUILayout.EndHorizontal();

    // nbGrains
    GUILayout.BeginHorizontal();
    float nbGrains = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Nbgrains);
    float newNbgrains = EditorGUILayout.Slider("nbGrains", nbGrains, 0.0f, 4.0f);
    if (nbGrains != newNbgrains) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Nbgrains, newNbgrains);
    }
    GUILayout.EndHorizontal();

    // outGainGrains
    GUILayout.BeginHorizontal();
    float outGainGrains = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Outgaingrains);
    float newOutgaingrains = EditorGUILayout.Slider("outGainGrains", outGainGrains, 0.0f, 1.0f);
    if (outGainGrains != newOutgaingrains) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Outgaingrains, newOutgaingrains);
    }
    GUILayout.EndHorizontal();

    // overLap
    GUILayout.BeginHorizontal();
    float overLap = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Overlap);
    float newOverlap = EditorGUILayout.Slider("overLap", overLap, 0.0f, 2.0f);
    if (overLap != newOverlap) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Overlap, newOverlap);
    }
    GUILayout.EndHorizontal();

    // playGrains
    GUILayout.BeginHorizontal();
    float playGrains = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Playgrains);
    float newPlaygrains = EditorGUILayout.Slider("playGrains", playGrains, 0.0f, 1.0f);
    if (playGrains != newPlaygrains) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Playgrains, newPlaygrains);
    }
    GUILayout.EndHorizontal();

    // randomOctave
    GUILayout.BeginHorizontal();
    float randomOctave = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Randomoctave);
    float newRandomoctave = EditorGUILayout.Slider("randomOctave", randomOctave, 1.0f, 100.0f);
    if (randomOctave != newRandomoctave) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Randomoctave, newRandomoctave);
    }
    GUILayout.EndHorizontal();

    // randomStart
    GUILayout.BeginHorizontal();
    float randomStart = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Randomstart);
    float newRandomstart = EditorGUILayout.Slider("randomStart", randomStart, 0.0f, 300000.0f);
    if (randomStart != newRandomstart) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Randomstart, newRandomstart);
    }
    GUILayout.EndHorizontal();

    // record
    GUILayout.BeginHorizontal();
    float record = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Record);
    float newRecord = EditorGUILayout.Slider("record", record, 0.0f, 1.0f);
    if (record != newRecord) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Record, newRecord);
    }
    GUILayout.EndHorizontal();

    // selectOutDry
    GUILayout.BeginHorizontal();
    float selectOutDry = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Selectoutdry);
    float newSelectoutdry = EditorGUILayout.Slider("selectOutDry", selectOutDry, 0.0f, 3.0f);
    if (selectOutDry != newSelectoutdry) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Selectoutdry, newSelectoutdry);
    }
    GUILayout.EndHorizontal();

    // selectOutGrains
    GUILayout.BeginHorizontal();
    float selectOutGrains = _dsp.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Selectoutgrains);
    float newSelectoutgrains = EditorGUILayout.Slider("selectOutGrains", selectOutGrains, 0.0f, 3.0f);
    if (selectOutGrains != newSelectoutgrains) {
      _dsp.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Selectoutgrains, newSelectoutgrains);
    }
    GUILayout.EndHorizontal();

    EditorGUI.indentLevel--;

    

    GUILayout.EndVertical();
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_gralunar_AudioLib : MonoBehaviour {
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_gralunar_AudioLib script = GetComponent<Hv_gralunar_AudioLib>();
        // Get and set a parameter
        float grainDur = script.GetFloatParameter(Hv_gralunar_AudioLib.Parameter.Graindur);
        script.SetFloatParameter(Hv_gralunar_AudioLib.Parameter.Graindur, grainDur + 0.1f);
    }
  */
  public enum Parameter : uint {
    Graindur = 0x97921D8A,
    Grainpitch = 0x778F92A8,
    Grainstart = 0xF7BE27C5,
    Ingaingrains = 0xC64CB795,
    Inputgrains = 0xEE8A6C27,
    Nbgrains = 0x6DE1B563,
    Outgaingrains = 0x82055C91,
    Overlap = 0xA439055A,
    Playgrains = 0x4FD4F750,
    Randomoctave = 0x31F25FD9,
    Randomstart = 0xDDF58D06,
    Record = 0xE8CB912F,
    Selectoutdry = 0x2F770D3B,
    Selectoutgrains = 0xA88643BA,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_gralunar_AudioLib script = GetComponent<Hv_gralunar_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_gralunar_AudioLib.FloatMessage message) {
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
  public float grainDur = 0.0f;
  public float grainPitch = 1.0f;
  public float grainStart = 0.0f;
  public float inGainGrains = 0.5f;
  public float inputGrains = 1.0f;
  public float nbGrains = 4.0f;
  public float outGainGrains = 0.5f;
  public float overLap = 2.0f;
  public float playGrains = 0.0f;
  public float randomOctave = 4.0f;
  public float randomStart = 0.0f;
  public float record = 0.0f;
  public float selectOutDry = 3.0f;
  public float selectOutGrains = 2.0f;

  // internal state
  private Hv_gralunar_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_gralunar_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_gralunar_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Graindur: return grainDur;
      case Parameter.Grainpitch: return grainPitch;
      case Parameter.Grainstart: return grainStart;
      case Parameter.Ingaingrains: return inGainGrains;
      case Parameter.Inputgrains: return inputGrains;
      case Parameter.Nbgrains: return nbGrains;
      case Parameter.Outgaingrains: return outGainGrains;
      case Parameter.Overlap: return overLap;
      case Parameter.Playgrains: return playGrains;
      case Parameter.Randomoctave: return randomOctave;
      case Parameter.Randomstart: return randomStart;
      case Parameter.Record: return record;
      case Parameter.Selectoutdry: return selectOutDry;
      case Parameter.Selectoutgrains: return selectOutGrains;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_gralunar_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Graindur: {
        x = Mathf.Clamp(x, 0.0f, 16000.0f);
        grainDur = x;
        break;
      }
      case Parameter.Grainpitch: {
        x = Mathf.Clamp(x, 0.0f, 16.0f);
        grainPitch = x;
        break;
      }
      case Parameter.Grainstart: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        grainStart = x;
        break;
      }
      case Parameter.Ingaingrains: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        inGainGrains = x;
        break;
      }
      case Parameter.Inputgrains: {
        x = Mathf.Clamp(x, 0.0f, 2.0f);
        inputGrains = x;
        break;
      }
      case Parameter.Nbgrains: {
        x = Mathf.Clamp(x, 0.0f, 4.0f);
        nbGrains = x;
        break;
      }
      case Parameter.Outgaingrains: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        outGainGrains = x;
        break;
      }
      case Parameter.Overlap: {
        x = Mathf.Clamp(x, 0.0f, 2.0f);
        overLap = x;
        break;
      }
      case Parameter.Playgrains: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        playGrains = x;
        break;
      }
      case Parameter.Randomoctave: {
        x = Mathf.Clamp(x, 1.0f, 100.0f);
        randomOctave = x;
        break;
      }
      case Parameter.Randomstart: {
        x = Mathf.Clamp(x, 0.0f, 300000.0f);
        randomStart = x;
        break;
      }
      case Parameter.Record: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        record = x;
        break;
      }
      case Parameter.Selectoutdry: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        selectOutDry = x;
        break;
      }
      case Parameter.Selectoutgrains: {
        x = Mathf.Clamp(x, 0.0f, 3.0f);
        selectOutGrains = x;
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
      Debug.LogWarning("Hv_gralunar_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(StringToHash(tableName), buffer);
  }

  public void FillTableWithMonoAudioClip(uint tableHash, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_gralunar_AudioLib: Only loading first channel of '" +
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
    _context = new Hv_gralunar_Context((double) AudioSettings.outputSampleRate);
    
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Graindur, grainDur);
    _context.SendFloatToReceiver((uint) Parameter.Grainpitch, grainPitch);
    _context.SendFloatToReceiver((uint) Parameter.Grainstart, grainStart);
    _context.SendFloatToReceiver((uint) Parameter.Ingaingrains, inGainGrains);
    _context.SendFloatToReceiver((uint) Parameter.Inputgrains, inputGrains);
    _context.SendFloatToReceiver((uint) Parameter.Nbgrains, nbGrains);
    _context.SendFloatToReceiver((uint) Parameter.Outgaingrains, outGainGrains);
    _context.SendFloatToReceiver((uint) Parameter.Overlap, overLap);
    _context.SendFloatToReceiver((uint) Parameter.Playgrains, playGrains);
    _context.SendFloatToReceiver((uint) Parameter.Randomoctave, randomOctave);
    _context.SendFloatToReceiver((uint) Parameter.Randomstart, randomStart);
    _context.SendFloatToReceiver((uint) Parameter.Record, record);
    _context.SendFloatToReceiver((uint) Parameter.Selectoutdry, selectOutDry);
    _context.SendFloatToReceiver((uint) Parameter.Selectoutgrains, selectOutGrains);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_gralunar_AudioLib.FloatMessage tempMessage;
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

class Hv_gralunar_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_gralunar_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_gralunar_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_gralunar_AudioLib.FloatMessage>();

    public Hv_gralunar_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_gralunar_AudioLib.FloatMessage msg = new Hv_gralunar_AudioLib.FloatMessage(receiverName, value);
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
  private static extern IntPtr hv_gralunar_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

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

  public Hv_gralunar_Context(double sampleRate, int poolKb=10, int inQueueKb=14, int outQueueKb=2) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_gralunar_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_gralunar_Context() {
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
