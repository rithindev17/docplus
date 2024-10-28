import { Disease as TDisease } from "../api/disease/Disease";

export const DISEASE_TITLE_FIELD = "id";

export const DiseaseTitle = (record: TDisease): string => {
  return record.id?.toString() || String(record.id);
};
