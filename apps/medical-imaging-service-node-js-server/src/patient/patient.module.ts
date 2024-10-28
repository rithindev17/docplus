import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { PatientModuleBase } from "./base/patient.module.base";
import { PatientService } from "./patient.service";
import { PatientController } from "./patient.controller";
import { PatientResolver } from "./patient.resolver";

@Module({
  imports: [PatientModuleBase, forwardRef(() => AuthModule)],
  controllers: [PatientController],
  providers: [PatientService, PatientResolver],
  exports: [PatientService],
})
export class PatientModule {}
