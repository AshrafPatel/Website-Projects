#!C:\Program Files\Python37\python.exe
from random import sample
import pickle
import mysql.connector
import cgi


print("Content-Type: text/html \n\n")
print("<style>")
print("body{ background-color: #ceb6f9; }")
print(".container { border-radius: 5px; background-color: #DCD6F7; padding: 20px;")
print("text-align: center; width: 80%; margin: auto; margin-bottom: 10px; }")
print("table{border-collapse: collapse; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; width: 100%;")
print("border: 5px solid rgb(128, 135, 172); color: #a6b1e1; margin: auto; margin-bottom: 30px;}")
print("th{ background-color: #8c94c4; height: 70px; font-size: 20px; color: black; transition: 0.7s; padding: 15px; }")
print("td{ padding: 10px; border: 5px solid #8087AC; }")
print("tr:nth-child(even){ background-color: #969ccd; color: black; }")
print("tr:nth-child(odd){ background-color: #9095c1; color: black; }")
print("th:hover{ opacity: 1; background-color: #b2c0f0; }")
print("tr:not(:first-child):hover{ background-size:  25% 25%; transform:scale(1.123,1.34); transform-origin:center; }")
print("h1{ font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; text-align: center; }")
print("h2{ font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; text-align: center; }")
print("</style>")

mydb = mysql.connector.connect(
    host="localhost",
    user="root",
    passwd="",
    database="project2"
)

mycursor = mydb.cursor()
query = "SELECT * FROM users WHERE NOT (FIRST_NAME = 'admin')"
mycursor.execute(query)
students = mycursor.fetchall()


class Student(object):
    def __init__(self, fName, lName, eMail, pNumber, pWord, regID, groupID):
        self.fName = fName
        self.lName = lName
        self.eMail = eMail
        self.pNumber = pNumber
        self.pWord = pWord
        self.regID = regID
        self.groupID = groupID

    def __repr__(self):
        return repr((self.fName, self.lName, self.eMail, self.pNumber, self.pWord, self.regID, self.groupID))

    def __getitem__(self, item):
        if item == 0:
            return self.fName
        elif item == 1:
            return self.lName
        elif item == 2:
            return self.eMail
        elif item == 3:
            return self.pNumber
        elif item == 4:
            return self.pWord
        elif item == 5:
            return self.regID
        elif item == 6:
            return self.groupID


sLength = len(students)
studentsArray = []

form = cgi.FieldStorage()

numberGen = form.getvalue('grp')
numberQuery = int(numberGen)
remainderStudents = 0
if (sLength % numberQuery) != 0:
    remainderStudents = sLength % numberQuery

newlist = sample(students, len(students))  # Copy and shuffle
groupCounter = 1  # Which group student delegated to
remainerCounter = 0  # Remainder counter
for x in newlist:
    if remainderStudents != 0 and remainerCounter != remainderStudents:
        x = (list(x))
        x.append('not verified waiting for more people')
        studentsArray.append(Student(x[0], x[1], x[2], x[3], x[4], x[5], x[6]))
        query = "UPDATE users SET GROUP_ID = %s WHERE REGID = %s"
        val = ("not verified waiting for more people", x[5])
        mycursor.execute(query, val)
        mydb.commit()
        remainerCounter += 1
        continue
    x = (list(x))
    x.append(str(groupCounter))
    studentsArray.append(Student(x[0], x[1], x[2], x[3], x[4], x[5], x[6]))
    query = "UPDATE users SET GROUP_ID = %s WHERE REGID = %s"
    val = (groupCounter, x[5])
    mycursor.execute(query, val)
    mydb.commit()
    if groupCounter == numberQuery:
        groupCounter = 0
    groupCounter += 1
    pass
mydb.close()
grouped = sorted(studentsArray, key=lambda student: student.groupID)
with open("../txt/groupfile.txt", "wb") as fp:   #Pickling
    pickle.dump(grouped, fp)


print("<h1>" + str(numberGen) + " groups generated successfully!</h1>")
gNumber = 1
while gNumber <= numberQuery:
    print("<div class='container'>")
    print("<h2>Group " + str(gNumber) + "</h2>")
    print("<table border=1>")
    print("<tr>")
    print("<th>First_Name</th><th>Last_Name</th><th>Email</th>")
    print("<th>Phone_Number</th><th>Password</th><th>regID</th><th>groupID</th>")
    print("</tr>")
    for a in grouped:
        if a[6] == str(gNumber):
            print("<tr>")
            print("<td>"+a[0]+"</td>")
            print("<td>"+a[1]+"</td>")
            print("<td>"+a[2]+"</td>")
            print("<td>"+a[3]+"</td>")
            print("<td>"+a[4]+"</td>")
            print("<td>"+a[5]+"</td>")
            print("<td>"+a[6]+"</td>")
            print("</tr>")
    print("</table>")
    print("</div><br><br>")
    gNumber += 1
    pass

if remainderStudents != 0:
    print("<div class='container'>")
    print("<h2>Table of students who have not been put into a group</h2>")
    print("<table border=1>")
    print("<tr>")
    print("<th>First_Name</th><th>Last_Name</th><th>Email</th>")
    print("<th>Phone_Number</th><th>Password</th><th>regID</th><th>groupID</th>")
    print("</tr>")
    for a in grouped:
        if a[6] == 'not verified waiting for more people':
            print("<tr>")
            print("<td>" + a[0] + "</td>")
            print("<td>" + a[1] + "</td>")
            print("<td>" + a[2] + "</td>")
            print("<td>" + a[3] + "</td>")
            print("<td>" + a[4] + "</td>")
            print("<td>" + a[5] + "</td>")
            print("<td>" + a[6] + "</td>")
            print("</tr>")
    print("</table>")
    print("</div>")
