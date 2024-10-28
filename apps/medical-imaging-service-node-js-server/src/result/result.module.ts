import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { ResultModuleBase } from "./base/result.module.base";
import { ResultService } from "./result.service";
import { ResultController } from "./result.controller";
import { ResultResolver } from "./result.resolver";

@Module({
  imports: [ResultModuleBase, forwardRef(() => AuthModule)],
  controllers: [ResultController],
  providers: [ResultService, ResultResolver],
  exports: [ResultService],
})
export class ResultModule {}
