import Form from "../../components/Form";
import { postStudent } from "../../services/students";

const SignUp = () => {
  const createStudent = (data) => postStudent({ body: data });
  return (
    <div className="flex flex-col items-center justify-center min-h-screen w-full">
      <h1 className="text-2xl font-bold mb-8">Create Student</h1>

      <Form onSubmit={createStudent} />
    </div>
  );
};

export default SignUp;
