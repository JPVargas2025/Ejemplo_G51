using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class ControllerScene_3: MonoBehaviour
{
    List<Student> list_student = new List<Student>();
    public TMP_InputField tnameS;
    public TMP_InputField tmailS;
    public TMP_InputField tageS;
    public TMP_InputField tcourseS;
    public TMP_InputField tcodeS;
    public TextMeshProUGUI panelText;
    string jsonPath;


    // Start is called once before the first execution of Update after the MonoBehaviour is created.

    void Start()
    {   jsonPath = Path.Combine(Application.persistentDataPath, "students.json");
        Debug.Log("JSON path: " + jsonPath);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStudent()
    {
        Student student = new Student(
            tcourseS.text,
            tcodeS.text,
            tnameS.text,
            tmailS.text,
            int.Parse(tageS.text)
        );
        list_student.Add(student);
        Debug.Log("Student added: " + student.NameP + " , " + student.MailP + " , " + 
            student.AgeP + " , " + student.CourseS + " , " + student.CodeS);

    }

    public void PrintConsole()
    { 
        foreach (Student s in list_student)
        {
            Debug.Log("Student: " + s.NameP + " , " + s.MailP + " , " + 
                s.AgeP + " , " + s.CourseS + " , " + s.CodeS);
        }
    }
    public void PrintPanel()
    {
        panelText.text = "";
        foreach (Student s in list_student)
        {
            panelText.text += "Student: " + s.NameP + " , " + s.MailP + " , " + 
                s.AgeP + " , " + s.CourseS + " , " + s.CodeS + "\n";
        }
    }
    public void SaveToJson()
    {
        StudentListWrapper wrapper = new StudentListWrapper();
        wrapper.students = list_student;
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(jsonPath, json);
        Debug.Log("JSON saved.");
    }
    public void LoadJson()
    {
        if (!File.Exists(jsonPath))
        {
            Debug.Log("JSON file not found.");
            return;
        }

        string json = File.ReadAllText(jsonPath);
        StudentListWrapper wrapper = JsonUtility.FromJson<StudentListWrapper>(json);
        list_student = wrapper.students;
        Debug.Log("JSON loaded. " + list_student.Count + " Students added.");
    }
}

