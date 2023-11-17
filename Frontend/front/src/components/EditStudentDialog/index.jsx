import PropTypes from "prop-types";

import Form from "../Form";
import DialogComponent from "../Dialog";
import { putStudent } from "../../services/students";

const EditStudentDialog = ({ close, open, initialValues }) => {
  const editStudent = (data) => putStudent({ body: data });

  return (
    <DialogComponent close={close} open={open}>
      <>
        <div className="flex justify-between items-center">
          <h1 className="text-2xl font-bold">Edit Student</h1>
          <button className="btn btn-sm" onClick={close}>X</button>
        </div>
        <Form initialValues={initialValues} onFinishingSubmit={close} onSubmit={editStudent} />
      </>
    </DialogComponent>
  );
};

EditStudentDialog.propTypes = {
  close: PropTypes.func.isRequired,
  open: PropTypes.bool.isRequired,
  initialValues: PropTypes.objectOf({
    name: PropTypes.string,
    email: PropTypes.string,
    phone: PropTypes.string,
    age: PropTypes.number,
  }),
};

export default EditStudentDialog;
