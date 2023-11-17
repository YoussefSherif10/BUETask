import { useEffect, useState } from "react";
import EditStudentDialog from "../../components/EditStudentDialog";
import { deleteStudent, getStudents } from "../../services/students";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const [openEditPopup, setOpenEditPopup] = useState(false);
  const [selectEditStudent, setSelectEditStudent] = useState({});
  const [students, setStudents] = useState([]);
  const navigate = useNavigate()

  useEffect(() => {
    const getAllStudents = async () => {
      const students = await getStudents();
      setStudents(students);
    };
    getAllStudents();
  }, []);

  return (
    <>
      <div className="flex flex-col items-center min-h-screen w-full pt-10">
        <div className="my-8 flex flex-col gap-4 w-3/4">
        <div className="flex justify-between items-center w-full">
        <h1 className="text-2xl font-bold">Students</h1>
        <button className="btn" onClick={() => navigate('/sign-up')}>Sign up</button>
        </div>
          <table className="table">
            {/* head */}
            <thead className="bg-gray-200">
              <tr>
                <th>Name</th>
                <th>age</th>
                <th>Phone</th>
                <th>Email</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {students.map((student) => (
                <tr key={student.studentId}>
                  <td>{student.name}</td>
                  <td>{student.age}</td>
                  <td>{student.phone}</td>
                  <td>{student.email}</td>
                  <td className="flex gap-3">
                    <button
                      onClick={() => {
                        setSelectEditStudent(student);
                        setOpenEditPopup(true);
                      }}
                      className="btn btn-primary text-white btn-sm"
                    >
                      Edit
                    </button>
                    <button
                      onClick={() => {
                        deleteStudent({ id: student.studentId });
                        setStudents(
                          students.filter(
                            (s) => s.studentId !== student.studentId
                          )
                        );
                      }}
                      className="btn btn-error text-white btn-sm"
                    >
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      {openEditPopup && (
        <EditStudentDialog
          close={() => setOpenEditPopup(false)}
          open={openEditPopup}
          initialValues={selectEditStudent}
        />
      )}
    </>
  );
};

export default Home;
