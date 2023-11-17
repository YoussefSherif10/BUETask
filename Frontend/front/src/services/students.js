import request from ".";

export const getStudents = async () => {
  const res = await request.get("students");

  return await res.data;
};

export const postStudent = async ({ body }) => {
  const res = await request.post("students", body);
  return await res.data;
};

export const putStudent = async ({ body }) => {
  const { studentId: id, ...restBody } = body;
  const res = await request.put(`students/${id}`, restBody);
  return await res.data;
};

export const deleteStudent = async ({ id }) => {
  const res = await request.delete(`students/${id}`);
  return await res.data;
};
