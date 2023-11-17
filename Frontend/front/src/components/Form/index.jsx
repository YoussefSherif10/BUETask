import { useForm } from "react-hook-form";
import PropTypes from "prop-types";
import { yupResolver } from "@hookform/resolvers/yup";

import { validation } from "./validation";
import { useNavigate } from "react-router-dom";

const Form = ({
  initialValues = {},
  onFinishingSubmit = () => ({}),
  onSubmit,
}) => {
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    clearErrors,
    formState: { errors },
    setError,
  } = useForm({
    defaultValues: initialValues,
    resolver: yupResolver(validation()),
  });

  const onFormSubmit = async (data) => {
    try {
      await onSubmit(data);
      onFinishingSubmit();
      navigate("/");
    } catch (error) {
      setError("email", { message: error.response.data.Message });
    }
  };

  const inputFields = [
    { id: "name", placeholder: "Name", type: "text" },
    { id: "email", placeholder: "Email", type: "email" },
    { id: "phone", placeholder: "Phone", type: "tel" },
    { id: "age", placeholder: "Age", type: "number", defaultValue: 1 },
  ];

  return (
    <form
      className="my-8 flex flex-col gap-4"
      onSubmit={(e) => {
        clearErrors();
        handleSubmit(onFormSubmit)(e);
      }}
    >
      {inputFields.map((field) => (
        <>
          <input
            defaultValue={field.defaultValue}
            key={field.id}
            className="input input-bordered"
            {...register(field.id)}
            placeholder={field.placeholder}
            type={field.type}
          />
          <label className="label">
            <span className="label-text-alt text-red-500">
              {errors[field.id]?.message}
            </span>
          </label>
        </>
      ))}
      <button className="btn btn-primary" type="submit">
        Submit
      </button>
    </form>
  );
};

Form.propTypes = {
  initialValues: PropTypes.objectOf({
    name: PropTypes.string,
    email: PropTypes.string,
    phone: PropTypes.string,
    age: PropTypes.number,
  }),
  onFinishingSubmit: PropTypes.func,
  onSubmit: PropTypes.func,
};

export default Form;
